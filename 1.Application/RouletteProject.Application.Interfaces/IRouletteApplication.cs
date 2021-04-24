﻿namespace RouletteProject.Application.Interfaces
{
    using Domain.Entities;
    using Generics;
    using System;


    public interface IRouletteApplication : IGenericApplication<Roulette>
    {
        Guid Create();
        
        bool OpenRoulette(Guid id);

        bool Bet(Guid userId, int numberToBet);
        
        bool CloseRoulette(Guid id);
    }
}
