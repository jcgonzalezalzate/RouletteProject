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
    }
}
