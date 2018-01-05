using GameOfLifeMvc.Engine.Interfaces;
using GameOfLifeMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameOfLifeMvc.Controllers
{
    public class GameEngineController : ApiController
    {
        private IGameOfLifeMvcEngine _gameEngine;

        public GameEngineController(IGameOfLifeMvcEngine gameEngine)
        {
            _gameEngine = gameEngine;
        }

        [Route("api/newGeneration")]
        [HttpPost]
        public IHttpActionResult GenerateNewGeneration([FromBody] GameData gameBoardData)
        {
            _gameEngine.GenerateNewGeneration(gameBoardData.InputData);
            return base.Content(HttpStatusCode.OK, gameBoardData.InputData);
        }

        [Route("api/get")]
        [HttpPost]
        public IEnumerable<string> Get()
        {
            _gameEngine.GenerateNewGeneration("asdasda");
            return new string[] { "value1", "value2" };
        }
    }
}
