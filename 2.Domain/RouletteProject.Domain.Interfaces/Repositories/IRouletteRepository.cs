namespace RouletteProject.Domain.Interfaces.Repositories
{
    using Entities;
    using System.Collections.Generic;

    public interface IRouletteRepository : IGenericRepository<Roulette>
    {
        bool OpenRoulette(Roulette roulette);

        IEnumerable<Bet> CloseRoulette(Roulette roulette);
    }
}
