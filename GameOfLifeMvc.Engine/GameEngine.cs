using GameOfLifeMvc.Engine.Helpers;
using GameOfLifeMvc.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLifeMvc.Engine
{
    public class GameEngine : IGameEngine
    {
        /// <summary>
        /// Heavy logic to return new generation
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string ReturnNewGeneration(string data)
        {
           

            return "";
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
            int dataRowLength = dataArray.Length;
            // i assume that this is mastrix... :)
            string[,] gameGrid = new string[dataRowLength, dataRowLength];
            for (int i = 0; i < dataRowLength; i++)
            {
                string[] columnArray = dataArray[i].Split(' ');
                int dataColumnLength = columnArray.Length;

                for (int j = 0; j < dataColumnLength; j++)
                {
                    gameGrid[i, j] = columnArray[j];
                }
            }

            return gameGrid;
        }       
    }
}
