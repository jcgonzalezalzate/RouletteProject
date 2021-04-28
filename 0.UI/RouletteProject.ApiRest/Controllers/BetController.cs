namespace RouletteProject.ApiRest.Controllers
{
    using Application.Interfaces;
    using Domain.Entities;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [ApiController]
    [Route("[controller]")]
    public class BetController : ControllerBase
    {
        protected readonly IBetApplication BetApplication;

        public BetController(IBetApplication betAplication)
        {
            BetApplication = betAplication;
        }
        
        [HttpPost]
        [Route("Bet")]
        public bool Bet([FromHeader] Guid userId, [FromBody] Bet bet)
        {
            bet.Id = Guid.NewGuid();
            bet.UserId = userId;
            bet.BetDateTime = DateTime.UtcNow;
            
            return BetApplication.SaveABet(bet);
        }

        [HttpGet]
        [Route("Get")]
        public Bet Get(Guid id)
        {
            return BetApplication.GetABet(id);
        }
    }
}
