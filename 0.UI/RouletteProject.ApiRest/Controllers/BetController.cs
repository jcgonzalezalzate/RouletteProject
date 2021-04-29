using System.Globalization;

namespace RouletteProject.ApiRest.Controllers
{
    using Application.Interfaces;
    using Domain.Entities;
    using Domain.Entities.DTO;
    using Domain.Entities.Enums;
    using Microsoft.AspNetCore.Mvc;
    using Models;
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
        public GenericResponse<bool> Bet([FromHeader] Guid userId, [FromBody] BetRequest betRequest)
        {
            var bet = new Bet
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                BetDateTime = DateTime.UtcNow,
                NumberToBet = betRequest.NumberToBet,
                AmountToBet = betRequest.AmountToBet,
                RouletteId = betRequest.RouletteId
            };
            Enum.TryParse(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(betRequest.ColourToBet), out Colour colourToBet);
            bet.ColourToBet = Enum.IsDefined(typeof(Colour), colourToBet) ? colourToBet : Colour.Undefined;

            return BetApplication.SaveABet(bet);
        }

        [HttpGet]
        [Route("Get")]
        public GenericResponse<Bet> Get(Guid id)
        {
            return BetApplication.GetABet(id);
        }
    }
}
