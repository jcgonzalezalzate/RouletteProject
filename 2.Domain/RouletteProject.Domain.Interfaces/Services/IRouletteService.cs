namespace RouletteProject.Domain.Interfaces.Services
{
    using Entities;
    using System;
    using System.Collections.Generic;

    public interface IRouletteService
    {
        Guid Create(Roulette roulette);

        bool OpenRoulette(Roulette roulette);

        IEnumerable<Bet> CloseRoulette(Roulette roulette);
    }
}
