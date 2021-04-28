using RouletteProject.Domain.Interfaces.Repositories;

namespace RouletteProject.Application.Services
{
    using Domain.Entities;
    using Domain.Interfaces.Services;
    using Generics;
    using Infrastructure.Helpers;
    using Interfaces;
    using System;

    public class BetApplication : GenericApplication<Bet>, IBetApplication
    {
        protected readonly IBetService BetService;

        protected readonly ICacheRepository CacheRepository;

        public BetApplication(
            IGenericService<Bet> genericService, 
            IBetService betService,
            ICacheRepository cacheRepository) 
            : base(genericService)
        {
            BetService = betService;
            CacheRepository = cacheRepository;
        }

        public Bet GetABet(Guid id)
        {
            return CatchErrorHelper.Try(() => BetService.GetABet(id));
        }

        public bool SaveABet(Bet bet)
        {
            return CatchErrorHelper.Try(() =>
            {
                var roulette = CacheRepository.Get<Roulette>(bet.Roulette.Id);
                bet.Roulette = roulette;
                bet.Roulette.Bets.Add(bet);
                BetService.IsValidBet(bet);
                BetService.AssignPrize(bet);
                CacheRepository.Save(roulette.Id, roulette);
                return true;
            });
        }
    }
}
