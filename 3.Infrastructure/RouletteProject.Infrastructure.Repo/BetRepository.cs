namespace RouletteProject.Infrastructure.Repo
{
    using Domain.Entities;
    using Generics;
    using Domain.Interfaces.Repositories;

    public class BetRepository : GenericRepository<Bet>, IBetRepository
    {
        public BetRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        
        public bool SaveABet(Bet bet)
        {
            return true;
        }
    }
}
