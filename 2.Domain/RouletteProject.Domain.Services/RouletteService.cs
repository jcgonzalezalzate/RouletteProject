namespace RouletteProject.Domain.Services
{
    using System;
    using RouletteProject.Domain.Interfaces.Services;
    using RouletteProject.Domain.Entities;
    using RouletteProject.Domain.Interfaces.Repositories;

    public class RouletteService : IRouletteService
    {
        public IRouletteRepository RouletteRepository { get; set; }

        public RouletteService(IRouletteRepository rouletteRepository)
        {
            RouletteRepository = rouletteRepository;
        }

        public Guid Create()
        {
            var roulette = new Roulette();
            roulette.Id = Guid.NewGuid();
            roulette.State = RouletteState.Open;
            var entity = this.RouletteRepository.Create(roulette);

            return entity.Id;
        }

        public bool OpenRoulette(Guid id)
        {
            return this.RouletteRepository.OpenRoulette(id);
        }

        public bool Bet(Guid userId, int numberToBet)
        {
            return this.RouletteRepository.Bet(userId: userId, numberToBet: numberToBet);
        }

        public bool CloseRoulette(Guid id)
        {
            return this.RouletteRepository.CloseRoulette(id);
        }
    }
}
