using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteProject.Domain.Entities;
using RouletteProject.Application.Interfaces;

namespace RouletteProject.Api.Controllers
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
            return this.RouletteApplication.Create();
        }

        [HttpPut]
        [Route("OpenRoulette")]
        public bool OpenRoulette(Guid id)
        {
            return this.RouletteApplication.OpenRoulette(id: id);
        }

        [HttpPost]
        [Route("Bet")]
        public bool Bet([FromHeader] Guid userId, [FromBody] int numberToBet)
        {
            return this.RouletteApplication.Bet(userId, numberToBet);
        }

        [HttpPut]
        [Route("CloseRoulette")]
        public bool CloseRoulette(Guid id)
        {
            return this.RouletteApplication.CloseRoulette(id: id);
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Roulette> GetAll()
        {
            return this.RouletteApplication.GetAll();
        }
    }
}
