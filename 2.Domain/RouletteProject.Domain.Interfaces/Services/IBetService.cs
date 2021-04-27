namespace RouletteProject.Domain.Interfaces.Services
{
    using Domain.Entities;

    public interface IBetService
    {
        bool SaveABet(Bet bet);
    }
}
