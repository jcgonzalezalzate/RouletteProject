namespace RouletteProject.Domain.Interfaces.Services
{
    using Entities;
    using System.Collections.Generic;

    public interface IRouletteService
    {
        bool IsValidRouletteToOpen(Roulette entity);

        Roulette CloseRoulette(Roulette roulette);
    }
}
