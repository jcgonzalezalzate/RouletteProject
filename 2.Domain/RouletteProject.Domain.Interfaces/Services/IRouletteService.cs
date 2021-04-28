namespace RouletteProject.Domain.Interfaces.Services
{
    using Entities;
    using System.Collections.Generic;

    public interface IRouletteService
    {
        List<Bet> CloseRoulette(Roulette roulette);
    }
}
