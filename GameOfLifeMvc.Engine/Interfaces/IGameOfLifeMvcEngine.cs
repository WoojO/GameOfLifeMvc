using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLifeMvc.Engine.Interfaces
{
    public interface IGameOfLifeMvcEngine
    {
        string GenerateNewGeneration(string gemaInputText);
    }
}
