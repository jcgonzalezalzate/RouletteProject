namespace RouletteProject.Infrastructure.Repo
{
    using Domain.Entities;
    using Domain.Interfaces.Repositories;
    using Generics;
    using Microsoft.Extensions.Caching.Distributed;
    using System.Collections.Generic;

    public class DynamoRepository : GenericRepository<Roulette>, IDynamoRepository
    {
        public DynamoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
