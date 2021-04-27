using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteProject.Domain.Entities;
using RouletteProject.Application.Interfaces;

namespace RouletteProject.ApiRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BetController : ControllerBase
    {
        protected readonly IBetApplication BetApplication;

        public BetController(IBetApplication betAplication)
        {
            this.BetApplication = betAplication;
        }
        
        [HttpPost]
        [Route("Bet")]
        public bool Bet([FromHeader] Guid userId, [FromBody] Bet bet)
        {
            bet.UserId = userId;
            bet.BetDateTime = DateTime.UtcNow;
            return this.BetApplication.SaveABet(bet);
        }
    }
}
