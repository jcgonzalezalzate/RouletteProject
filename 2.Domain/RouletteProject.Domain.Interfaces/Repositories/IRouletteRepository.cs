using System;

namespace RouletteProject.Domain.Interfaces.Repositories
{
    using Entities;

    public interface IRouletteRepository : IGenericRepository<Roulette>
    {
        bool OpenRoulette(Guid id);
        
        bool Bet(Guid userId, int numberToBet);
        
        bool CloseRoulette(Guid id);
    }
}
