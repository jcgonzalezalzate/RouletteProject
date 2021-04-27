namespace RouletteProject.Domain.Interfaces.Repositories
{
    using Entities;

    public interface IBetRepository : IGenericRepository<Bet>
    {
        bool SaveABet(Bet bet);
    }
}
