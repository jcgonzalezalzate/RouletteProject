namespace RouletteProject.Application.Interfaces
{
    using Domain.Entities;
    using Generics;
    using System;

    public interface IBetApplication : IGenericApplication<Bet>
    {
        Bet GetABet(Guid id);

        bool SaveABet(Bet bet);
    }
}
