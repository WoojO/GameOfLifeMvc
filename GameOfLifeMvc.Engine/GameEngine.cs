using GameOfLifeMvc.Engine.Helpers;
using GameOfLifeMvc.Engine.Interfaces;
using System;
using GameOfLifeMvc.Engine.Helpers;
using System.Collections.Generic;
using System.Text;

namespace GameOfLifeMvc.Engine
{
    public class GameEngine : IGameEngine
    {
        string LIVE_CELL = "1";
        string DEAD_CELL = "0";

        int dataRowLength;
        int dataColumnLength;
        string[,] newGrid;
        string[,] gameGrid;
        /// <summary>
        /// Heavy logic to return new generation
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string ReturnNewGeneration(string data)
        {
            gameGrid = CreateCurrentGrid(data);
            var newGrid = CalculateNewGeneration();

            return newGrid.ToStringFormat();
        }

        /// <summary>
        /// Simple validation of input array
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Validate(string data)
        {
            try
            {
                string[] dataArray = EngineHelper.ClearEmptyLines(data);
                int itemsCount = dataArray.Length;
                for (int i = 0; i < itemsCount; i++)
                {
                    int lineLength = dataArray[i].Replace(" ", string.Empty).Length;
                    if (lineLength != itemsCount)
                        return false;
                }
            }
            catch (Exception)
            {
                // log 
                return false;
            }

            return true;
        }

        private string[,] CreateCurrentGrid(string data)
        {
            string[] dataArray = EngineHelper.ClearEmptyLines(data);
            dataRowLength = dataArray.GetLength(0);
            // my assumption that this is square matrix
            string[,] gameGrid = new string[dataRowLength, dataRowLength];
            for (int i = 0; i < dataRowLength; i++)
            {
                string[] columnArray = dataArray[i].Split(' ');

                dataColumnLength = columnArray.GetLength(0);

                for (int j = 0; j < dataColumnLength; j++)
                {
                    gameGrid[i, j] = columnArray[j];
                }
            }

            return gameGrid;
        }

        private string[,] CalculateNewGeneration()
        {
            newGrid = (string[,])gameGrid.Clone();
            for (int i = 0; i < dataRowLength; i++)
            {
                for (int j = 0; j < dataColumnLength; j++)
                {
                    // calculate live cells around current cell
                    int liveCellCount = CalculateLiveCells(i, j);
 
                    if (gameGrid[i, j].Equals(DEAD_CELL))
                    {
                        if (liveCellCount == 3)
                            newGrid[i, j] = LIVE_CELL;
                    }
                    else
                    {
                        if (liveCellCount == 2 || liveCellCount == 3)
                            newGrid[i, j] = LIVE_CELL;
                        else
                            newGrid[i, j] = DEAD_CELL;
                    }
                }

            }
            return newGrid;
        }

        private int CalculateLiveCells(int i, int j)
        {
            int liveCells = 0;

            liveCells = LiveNeighbors(i, j);

            return liveCells;
        }

        #region [  calculate live cells  ]
        bool ValidCellX(int x) => 0 <= x && x < dataRowLength;
        bool ValidCellY(int y) => 0 <= y && y < dataColumnLength;
        int ValidOrDead(int x, int y) => ValidCellX(x) && ValidCellY(y) ? Convert.ToInt32(gameGrid[x, y]) : 0;
        int North(int x, int y) => ValidOrDead(x, y - 1);
        int South(int x, int y) => ValidOrDead(x, y + 1);
        int West(int x, int y) => ValidOrDead(x - 1, y);
        int East(int x, int y) => ValidOrDead(x + 1, y);
        int NorthEast(int x, int y) => ValidOrDead(x + 1, y - 1);
        int NorthWest(int x, int y) => ValidOrDead(x - 1, y - 1);
        int SouthEast(int x, int y) => ValidOrDead(x + 1, y + 1);
        int SouthWest(int x, int y) => ValidOrDead(x - 1, y + 1);
        int LiveNeighbors(int x, int y) => North(x, y) + South(x, y) + West(x, y) + East(x, y) + NorthEast(x, y) + NorthWest(x, y) + SouthEast(x, y) + SouthWest(x, y);
        #endregion
    }
}
