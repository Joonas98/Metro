using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace GameWebApi.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayersController : ControllerBase
    {
        private readonly ILogger<PlayersController> _logger;
        private readonly IRepository _repository;
        public PlayersController(ILogger<PlayersController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet]
        [Route("{id}")]
        public Task<Player> Get(Guid id)
        {
            return _repository.Get(id);
        }
        [HttpGet]
        [Route("Getall")]
        public Task<Player[]> GetAll()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        [Route("Create")]

        public Task<Player> Create([FromBody] NewPlayer player)
        {
            Player newPlayer = new Player() { Id = Guid.NewGuid(), Name = player.Name };

            return _repository.Create(newPlayer);
        }
        // [HttpPost]
        // [Route("Modify")]
        // public Task<Player> Modify([FromBody] Guid id, [FromBody] ModifiedPlayer player)
        // {
        //     return _repository.Modify(id, player);
        // }
        [HttpPost]
        [Route("Delete")]
        public Task<Player> Delete([FromBody] Guid id)
        {
            return _repository.Delete(id);
        }
    }


}


