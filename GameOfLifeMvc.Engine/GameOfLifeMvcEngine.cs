using GameOfLifeMvc.Engine.Interfaces;
using System;

namespace GameOfLifeMvc.Engine
{
    public class GameOfLifeMvcEngine: IGameOfLifeMvcEngine
    {
        private IGameEngine _gameEngine;
        public GameOfLifeMvcEngine(IGameEngine gameEngine)
        {
            _gameEngine = gameEngine;
        }

        public string GenerateNewGeneration(string gamaInputText)
        {
            if (!_gameEngine.Validate(gamaInputText))
                return null;
            return _gameEngine.ReturnNewGeneration(gamaInputText);
        }
    }
}
