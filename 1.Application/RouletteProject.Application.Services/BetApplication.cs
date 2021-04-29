namespace RouletteProject.Application.Services
{
    using Domain.Entities;
    using Domain.Entities.DTO;
    using Domain.Interfaces.Repositories;
    using Domain.Interfaces.Services;
    using Generics;
    using Infrastructure.Helpers;
    using Interfaces;
    using System;
    using System.Collections.Generic;

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

        public GenericResponse<Bet> GetABet(Guid id)
        {
            return CatchErrorHelper.Try(() => BetService.GetABet(id));
        }

        public GenericResponse<bool> SaveABet(Bet bet)
        {
            return CatchErrorHelper.Try(() =>
            {
                var roulette = CacheRepository.Get<Roulette>(bet.RouletteId);
                roulette.Bets ??= new List<Bet>();
                roulette.Bets.Add(bet);
                BetService.IsValidBet(bet);
                BetService.IsValidRoulette(roulette);
                BetService.AssignPrize(bet);
                CacheRepository.Save(roulette.Id, roulette);
                return true;
            });
        }
    }
}
