
namespace RouletteProject.Domain.Services.Bet
{
    using Validators;
    using Entities.Enums;
    using Entities;
    using Interfaces.Repositories;
    using Interfaces.Services;
    using System;

    public class BetService : IBetService
    {
        protected readonly ICacheRepository CacheRepository;

        public BetService(ICacheRepository cacheRepository)
        {
            CacheRepository = cacheRepository;
        }

        public Entities.Bet GetABet(Guid id)
        {
            return CacheRepository.Get<Entities.Bet>(id);
        }

        public bool IsValidBet(Bet bet)
        {
            var validator = new GeneralValidator();
            var result = validator.Validate(bet);
            
            if (!result.IsValid)
            {
                throw new Exception(result.Errors[0].ErrorMessage);
            }

            return true;
        }
        
        public void AssignPrize(Bet bet)
        {
            if (bet.NumberToBet.HasValue && bet.NumberToBet > 0)
            {
                bet.AmountToWin = bet.AmountToBet * 5;
            }

            if (bet.ColourToBet.HasValue && bet.ColourToBet > 0)
            {
                bet.AmountToWin = bet.AmountToBet * (decimal) 1.8;
            }
        }
    }
}
