namespace RouletteProject.Infrastructure.Repo
{
    using Domain.Entities;
    using Domain.Interfaces.Repositories;
    using Generics;
    using Microsoft.Extensions.Caching.Distributed;
    using System.Collections.Generic;

    public class DynamoRepository : GenericRepository<Roulette>, IDynamoRepository
    {
        protected readonly IDistributedCache CacheContext;

        public DynamoRepository(
            RepositoryContext repositoryContext,
            IDistributedCache cacheContext)
            : base(repositoryContext)
        {
            CacheContext = cacheContext;
        }
        
        public IEnumerable<Bet> CloseRoulette(Roulette roulette)
        {
            RepositoryContext.SaveAsync(roulette);
            return new List<Bet>();
        }
    }
}
