namespace RouletteProject.Domain.Services.Bet
{
    using Entities;
    using Entities.Enums;
    using Interfaces.Repositories;
    using Interfaces.Services;
    using System;
    using System.Linq;
    using Validators;

    public class BetService : IBetService
    {
        protected readonly ICacheRepository CacheRepository;

        public BetService(ICacheRepository cacheRepository)
        {
            CacheRepository = cacheRepository;
        }

        public Bet GetABet(Guid id)
        {
            return CacheRepository.Get<Entities.Bet>(id);
        }

        public bool IsValidBet(Bet bet)
        {
            var validator = new GeneralValidator();
            var result = validator.Validate(bet);
            
            if (!result.IsValid)
            {
                throw new Exception(message: string.Join(separator: '|', values: result.Errors.Select(e => e.ErrorMessage)));
            }

            return true;
        }

        public bool IsValidRoulette(Roulette roulette)
        {
            if (roulette.State != RouletteState.Opened)
            {
                throw new Exception("Apuesta inválida: la ruleta debe estar en estado abierto.");
            }

            return true;
        }

        public void AssignPrize(Bet bet)
        {
            if (bet.NumberToBet > 0)
            {
                bet.AmountToWin = bet.AmountToBet * 5;
            }

            if (bet.ColourToBet > 0)
            {
                bet.AmountToWin = bet.AmountToBet * (decimal) 1.8;
            }
        }
    }
}
