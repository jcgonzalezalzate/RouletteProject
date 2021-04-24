namespace RouletteProject.Domain.Interfaces.Services
{
    using System;

    public interface IRouletteService
    {
        Guid Create();

        bool OpenRoulette(Guid id);

        bool Bet(Guid userId, int numberToBet);
        
        bool CloseRoulette(Guid id);
    }
}
