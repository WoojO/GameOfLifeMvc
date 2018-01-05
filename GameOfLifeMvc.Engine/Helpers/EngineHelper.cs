using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLifeMvc.Engine.Helpers
{
    public static class EngineHelper
    {
        public static string[] ClearEmptyLines(string data)
        {
            string[] splitDataArray = data.Split('\n');
            List<string> validData = new List<string>();
            int itemsDataCount = splitDataArray.Length;
            for (int i = 0; i < itemsDataCount; i++)
            {
                if (splitDataArray[i].Length != 0)
                    validData.Add(splitDataArray[i]);
            }
            string[] dataArray = validData.ToArray();
            return dataArray;
        }
    }
}
