using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLifeMvc.Engine.Helpers
{
    public static class EngineExtensions
    {
        public static string ToStringFormat(this string[,] stringArray)
        {
            StringBuilder result = new StringBuilder();

            var sizeI = stringArray.GetLength(0);
            var sizeJ = stringArray.GetLength(1);

            for (int i = 0; i < sizeI; i++)
            {                
                for (int j = 0; j < sizeJ; j++)
                {
                    result.Append(stringArray[i, j]);
                    result.Append(" ");
                }
                result.Remove(result.Length - 1, 1);
                result.Append("\n");
            }

            return result.ToString();
        }
    }
}
