namespace RouletteProject.Domain.Services
{
    using Entities;
    using Entities.Enums;
    using Interfaces.Repositories;
    using Interfaces.Services;
    using System;
    using System.Collections.Generic;

    public class RouletteService : IRouletteService
    {
        public IRouletteRepository RouletteRepository { get; set; }

        public RouletteService(IRouletteRepository rouletteRepository)
        {
            RouletteRepository = rouletteRepository;
        }

        public Guid Create(Roulette roulette)
        {
            var entity = this.RouletteRepository.Create(roulette);

            return entity.Id;
        }

        public bool OpenRoulette(Roulette roulette)
        {
            return this.RouletteRepository.OpenRoulette(roulette);
        }
        
        public IEnumerable<Bet> CloseRoulette(Roulette roulette)
        {
            roulette.WinningNumber = new Random().Next(0, 36);
            roulette.WinningColour = roulette.WinningNumber % 2 == 0 ? Colour.Red : Colour.Black;
            
            return this.RouletteRepository.CloseRoulette(roulette);
        }
    }
}
