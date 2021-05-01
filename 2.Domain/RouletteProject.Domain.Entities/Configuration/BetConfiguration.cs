namespace RouletteProject.Domain.Entities.Configuration
{
    public class BetConfiguration
    {
        public int MinimumRoulletteNumber { get; set; }

        public int MaximumRoulletteNumber { get; set; }

        public decimal MultiplyingFactorByNumber { get; set; }

        public decimal MultiplyingFactorByColour { get; set; }
    }
}
