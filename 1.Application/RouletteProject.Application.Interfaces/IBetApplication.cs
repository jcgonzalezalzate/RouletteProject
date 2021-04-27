namespace RouletteProject.Application.Interfaces
{
    using Domain.Entities;
    using Generics;

    public interface IBetApplication : IGenericApplication<Bet>
    {
        bool SaveABet(Bet bet);
    }
}
