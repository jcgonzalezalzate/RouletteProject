namespace RouletteProject.Domain.Interfaces.Services
{
    using Entities;
    using System;

    public interface IBetService
    {
        Bet GetABet(Guid id);

        bool IsValidBet(Bet bet);

        bool IsValidRoulette(Roulette roulette);

        void AssignPrize(Bet bet);
    }
}
