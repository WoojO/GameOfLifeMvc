using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLifeMvc.Engine.Interfaces
{
    public interface IGameEngine
    {
        bool Validate(string data);
        string ReturnNewGeneration(string data);
    }
}
