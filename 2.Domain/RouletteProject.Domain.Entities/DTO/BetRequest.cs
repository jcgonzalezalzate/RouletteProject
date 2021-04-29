using System;

namespace RouletteProject.ApiRest.Models
{
    public class BetRequest
    {
        public Guid RouletteId { get; set; }

        public int NumberToBet { get; set; }

        public string ColourToBet { get; set; }

        public decimal AmountToBet { get; set; }
    }
}
