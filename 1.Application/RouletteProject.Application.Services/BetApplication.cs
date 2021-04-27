using System;
using RouletteProject.Domain.Interfaces.Services;
using RouletteProject.Infrastructure.Helpers;

namespace RouletteProject.Application.Services
{
    using Domain.Entities;
    using Generics;
    using Interfaces;

    public class BetApplication : GenericApplication<Bet>, IBetApplication
    {
        protected readonly IBetService BetService;

        public BetApplication(IGenericService<Bet> genericService, IBetService betService) : base(genericService)
        {
            this.BetService = betService;
        }

        public bool SaveABet(Bet bet)
        {
            return CatchErrorHelper.Try(() => this.BetService.SaveABet(bet));
        }
    }
}
