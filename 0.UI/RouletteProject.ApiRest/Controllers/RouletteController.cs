using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteProject.Domain.Entities;
using RouletteProject.Application.Interfaces;
using RouletteProject.Domain.Entities.Enums;

namespace RouletteProject.ApiRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouletteController : ControllerBase
    {
        protected readonly IRouletteApplication RouletteApplication;

        public RouletteController(IRouletteApplication rouletteAplication)
        {
            this.RouletteApplication = rouletteAplication;
        }

        [HttpPost]
        [Route("Create")]
        public Guid Create()
        {
            var roulette = new Roulette { Id = Guid.NewGuid(), State = RouletteState.Open };
            return this.RouletteApplication.Create(roulette);
        }

        [HttpPut]
        [Route("OpenRoulette")]
        public bool OpenRoulette(Guid id)
        {
            var roulette = new Roulette { Id = id, OpenDateTime = DateTime.UtcNow };
            return this.RouletteApplication.OpenRoulette(roulette);
        }
        
        [HttpPut]
        [Route("CloseRoulette")]
        public IEnumerable<Bet> CloseRoulette(Guid id)
        {
            var roulette = new Roulette { Id = id, CloseDateTime = DateTime.UtcNow, State = RouletteState.Close};
            return this.RouletteApplication.CloseRoulette(roulette);
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Roulette> GetAll()
        {
            return this.RouletteApplication.GetAll();
        }
    }
}
