
namespace RouletteProject.Application.Services
{
    using Domain.Entities;
    using Domain.Entities.DTO;
    using Domain.Entities.Enums;
    using Domain.Interfaces.Repositories;
    using Domain.Interfaces.Services;
    using Generics;
    using Infrastructure.Helpers;
    using Interfaces;
    using System;

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

        public GenericResponse<Guid> Create()
        {
            return CatchErrorHelper.Try(() =>
            {
                var roulette = new Roulette();
                roulette.Id = Guid.NewGuid();
                roulette.State = RouletteState.Created;
                roulette.CreationDateTime = DateTime.UtcNow;
                DynamoRepository.Create(roulette);
                return roulette.Id;
            });
        }

        public GenericResponse<bool> OpenRoulette(Guid id)
        {
            return CatchErrorHelper.Try(() =>
            {
                var entity = DynamoRepository.Details(id);

                if (entity == null)
                {
                    throw new Exception($"Ruleta no encontrada con Id: {id}");
                }

                RouletteService.IsValidRouletteToOpen(entity);
                entity.State = RouletteState.Opened;
                entity.OpenDateTime = DateTime.UtcNow;
                DynamoRepository.Edit(entity);
                CacheRepository.Save(id, entity);
                return true;
            });
        }
        
        public GenericResponse<Roulette> CloseRoulette(Guid id)
        {
            return CatchErrorHelper.Try(() =>
            {
                var rouletteInCache = this.CacheRepository.Get<Roulette>(id);

                if (rouletteInCache.State != RouletteState.Closed)
                {
                    rouletteInCache.State = RouletteState.Closed;
                    rouletteInCache.CloseDateTime = DateTime.UtcNow;
                    RouletteService.CloseRoulette(rouletteInCache);
                }

                CacheRepository.Save(id, rouletteInCache);
                DynamoRepository.Edit(rouletteInCache);
                return rouletteInCache;
            });
        }
    }
}
