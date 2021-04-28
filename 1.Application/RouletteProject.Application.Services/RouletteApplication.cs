namespace RouletteProject.Application.Services
{
    using Domain.Entities;
    using Domain.Entities.Enums;
    using Domain.Interfaces.Repositories;
    using Domain.Interfaces.Services;
    using Generics;
    using Infrastructure.Helpers;
    using Interfaces;
    using System;
    using System.Collections.Generic;

    public class RouletteApplication : GenericApplication<Roulette>, IRouletteApplication
    {
        protected readonly IRouletteService RouletteService;

        protected readonly ICacheRepository CacheRepository;

        protected readonly IDynamoRepository DynamoRepository;

        public RouletteApplication(
            IGenericService<Roulette> genericService, 
            IRouletteService rouletteService,
            ICacheRepository cacheRepository,
            IDynamoRepository dynamoRepository) 
            : base(genericService)
        {
            RouletteService = rouletteService;
            CacheRepository = cacheRepository;
            DynamoRepository = dynamoRepository;
        }

        public Guid Create(Roulette roulette)
        {
            return CatchErrorHelper.Try(() =>
            {
                roulette.State = RouletteState.Created;
                roulette.CreationDateTime = DateTime.UtcNow;
                DynamoRepository.Create(roulette);
                return roulette.Id;
            });
        }

        public bool OpenRoulette(Roulette roulette)
        {
            return CatchErrorHelper.Try(() =>
            {
                roulette.State = RouletteState.Opened;
                roulette.OpenDateTime = DateTime.UtcNow;
                DynamoRepository.Edit(roulette);
                CacheRepository.Save(roulette.Id, roulette);
                return true;
            });
        }
        
        public IEnumerable<Bet> CloseRoulette(Roulette roulette)
        {
            return CatchErrorHelper.Try(() =>
            {
                roulette.State = RouletteState.Closed;
                roulette.CloseDateTime = DateTime.UtcNow;
                var rouletteInCache = this.CacheRepository.Get<Roulette>(roulette.Id);
                return RouletteService.CloseRoulette(rouletteInCache);
            });
        }
    }
}
