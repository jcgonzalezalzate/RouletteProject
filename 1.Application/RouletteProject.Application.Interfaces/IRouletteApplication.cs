namespace RouletteProject.Application.Interfaces
{
    using Domain.Entities;
    using Generics;
    using System;
    using System.Collections.Generic;

    public interface IRouletteApplication : IGenericApplication<Roulette>
    {
        Guid Create(Roulette roulette);
        
        bool OpenRoulette(Roulette roulette);

        IEnumerable<Bet> CloseRoulette(Roulette roulette);
    }
}
