namespace RouletteProject.Domain.Interfaces.Services
{
    using Entities;
    using System;

    public interface IBetService
    {
        Bet GetABet(Guid id);

        bool IsValidBet(Bet bet);

        void AssignPrize(Bet bet);
    }
}
