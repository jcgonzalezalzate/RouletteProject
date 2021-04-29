using System;
using RouletteProject.Domain.Entities.Enums;

namespace RouletteProject.Domain.Services.Bet.Validators
{
    using Entities;
    using FluentValidation;

    public class GeneralValidator : AbstractValidator<Bet>
    {
        public GeneralValidator()
        {
            this.RuleFor(b => b).Must(this.MustAUserId).WithMessage($"Apuesta inválida: debe ingresar un UserId.");
            this.RuleFor(b => b).Must(this.MustMinimumBet).WithMessage($"Apuesta inválida: debe apostar a número o a color."); 
            this.RuleFor(b => b).Must(this.MustHaveJustOneBet).WithMessage($"Apuesta inválida: sólo puede apostar a número o a color, no a ambos en la misma apuesta.");
            this.RuleFor(b => b).Must(this.MustBeInAmountRange).WithMessage($"Apuesta inválida: debe apostar una cantidad entre 1 y 10.000 dólares.");
            this.RuleFor(b => b).Must(this.MustBeInNumberRange).WithMessage($"Apuesta inválida: el número a apostar debe estar entre 0 y 36.");
        }
        private bool MustAUserId(Bet bet)
        {
            return bet.UserId != Guid.Empty;
        }
        
        private bool MustMinimumBet(Bet bet)
        {
            return bet.NumberToBet > 0 || bet.ColourToBet > 0;
        }

        private bool MustHaveJustOneBet(Bet bet)
        {
            return !(bet.NumberToBet > 0 && bet.ColourToBet > 0);
        }

        private bool MustBeInAmountRange(Bet bet)
        {
            return bet.AmountToBet <= 10000 && bet.AmountToBet > 0;
        }

        private bool MustBeInNumberRange(Bet bet)
        {
            if (bet.NumberToBet > 0 && (0 > bet.NumberToBet || bet.NumberToBet > 36))
            {
                return false;
            }

            return true;
        }
    }
}