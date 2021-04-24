using System;

namespace RouletteProject.Infrastructure.Repo
{
    using Domain.Entities;
    using Generics;
    using Domain.Interfaces.Repositories;

    public class RouletteRepository : GenericRepository<Roulette>, IRouletteRepository
    {
        public RouletteRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public bool OpenRoulette(Guid id)
        {
            return true;
        }

        public bool Bet(Guid userId, int numberToBet)
        {
            return true;
        }

        public bool CloseRoulette(Guid id)
        {
            return true;
        }
    }
}
