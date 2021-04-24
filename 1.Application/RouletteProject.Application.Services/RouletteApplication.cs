using System;
using RouletteProject.Domain.Interfaces.Services;
using RouletteProject.Infrastructure.Helpers;

namespace RouletteProject.Application.Services
{
    using Domain.Entities;
    using Generics;
    using Interfaces;

    public class RouletteApplication : GenericApplication<Roulette>, IRouletteApplication
    {
        protected readonly IRouletteService RouletteService;


        public RouletteApplication(IGenericService<Roulette> genericService, IRouletteService rouletteService) : base(genericService)
        {
            this.RouletteService = rouletteService;
        }

        public Guid Create()
        {
            return CatchErrorHelper.Try(() => this.RouletteService.Create());
        }

        public bool OpenRoulette(Guid id)
        {
            return CatchErrorHelper.Try(() => this.RouletteService.OpenRoulette(id: id));
        }

        public bool Bet(Guid userId, int numberToBet)
        {
            return CatchErrorHelper.Try(() => this.RouletteService.Bet(userId: userId, numberToBet: numberToBet));
        }

        public bool CloseRoulette(Guid id)
        {
            return CatchErrorHelper.Try(() => this.RouletteService.CloseRoulette(id: id));
        }
    }
}
