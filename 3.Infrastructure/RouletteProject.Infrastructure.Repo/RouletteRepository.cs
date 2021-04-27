namespace RouletteProject.Infrastructure.Repo
{
    using Domain.Entities;
    using Domain.Interfaces.Repositories;
    using Generics;
    using System.Collections.Generic;

    public class RouletteRepository : GenericRepository<Roulette>, IRouletteRepository
    {
        private RepositoryContext RepositoryContext { get; set; };

        public RouletteRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public bool OpenRoulette(Roulette roulette)
        {
            this.RepositoryContext.SaveAsync(roulette);
            return true;
        }
        
        public bool CloseRoulette(Roulette roulette)
        {
            this.RepositoryContext.SaveAsync(roulette);
            return true;
        }
    }
}
