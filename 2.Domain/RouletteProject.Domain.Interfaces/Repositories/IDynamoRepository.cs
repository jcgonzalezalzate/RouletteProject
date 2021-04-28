namespace RouletteProject.Domain.Interfaces.Repositories
{
    using Entities;
    using System.Collections.Generic;

    public interface IDynamoRepository : IGenericRepository<Roulette>
    {
        IEnumerable<Bet> CloseRoulette(Roulette roulette);
    }
}
