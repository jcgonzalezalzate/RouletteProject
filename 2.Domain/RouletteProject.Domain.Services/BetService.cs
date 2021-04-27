using RouletteProject.Domain.Entities.Enums;

namespace RouletteProject.Domain.Services
{
    using System;
    using RouletteProject.Domain.Interfaces.Services;
    using RouletteProject.Domain.Entities;
    using RouletteProject.Domain.Interfaces.Repositories;

    public class BetService : IBetService
    {
        public IBetRepository BetRepository { get; set; }

        public BetService(IBetRepository betRepository)
        {
            BetRepository = betRepository;
        }
        
        public bool SaveABet(Bet bet)
        {
            this.ValidateBet(bet);
            this.ValidateNumber(bet.NumberToBet);
            this.AssignPrize(bet);
            return this.BetRepository.SaveABet(bet);
        }
        
        private void ValidateBet(Bet bet)
        {
            if (!bet.NumberToBet.HasValue && !bet.ColourToBet.HasValue)
            {
                throw new Exception("Apuesta inválida: debe apostar a algún número o a algún color.");
            }

            if (bet.AmountToBet > 10000 || bet.AmountToBet < 0)
            {
                throw new Exception("Apuesta inválida: debe apostar una cantidad entre 1 y 10.000 dólares.");
            }
        }

        private void ValidateNumber(int? numberToBet)
        {
            if (!numberToBet.HasValue)
            {
                return;
            }

            if (0 > numberToBet || numberToBet > 36)
            {
                throw new Exception("Apuesta inválida: el número a apostar debe estar entre 0 y 36.");
            }
        }

        private void AssignPrize(Bet bet)
        {
            if (bet.NumberToBet.HasValue)
            {
                bet.AmountToWin = bet.AmountToBet * 5;
            }

            if (bet.ColourToBet.HasValue)
            {
                bet.AmountToWin = bet.AmountToBet * (decimal) 1.8;
            }
        }
    }
}
