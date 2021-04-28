namespace RouletteProject.ApiRest.Controllers
{
    using Application.Interfaces;
    using Domain.Entities;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    [ApiController]
    [Route("[controller]")]
    public class RouletteController : ControllerBase
    {
        protected readonly IRouletteApplication RouletteApplication;

        public RouletteController(IRouletteApplication rouletteAplication)
        {
            RouletteApplication = rouletteAplication;
        }

        [HttpPost]
        [Route("Create")]
        public Guid Create()
        {
            var roulette = new Roulette { Id = Guid.NewGuid() };
            return RouletteApplication.Create(roulette);
        }

        [HttpPut]
        [Route("OpenRoulette")]
        public bool OpenRoulette(Guid id)
        {
            var roulette = new Roulette { Id = id };
            return RouletteApplication.OpenRoulette(roulette);
        }
        
        [HttpPut]
        [Route("CloseRoulette")]
        public IEnumerable<Bet> CloseRoulette(Guid id)
        {
            var roulette = new Roulette { Id = id };
            return RouletteApplication.CloseRoulette(roulette);
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Roulette> GetAll()
        {
            return RouletteApplication.GetAll();
        }
    }
}
