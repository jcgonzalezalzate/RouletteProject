namespace RouletteProject.Domain.Entities
{
    using Enums;
    using Generics;
    using System;

    public class Bet : GenericEntity
    {
        public Roulette Roulette { get; set; }

        public DateTime BetDateTime { get; set; }

        public Guid UserId { get; set; }

        public int? NumberToBet { get; set; }

        public Colour? ColourToBet { get; set; }

        public decimal AmountToBet { get; set; }

        public decimal AmountToWin { get; set; }

        public bool WasWinner { get; set; }
    }
}
