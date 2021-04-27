namespace RouletteProject.Application.Services
{
    using Domain.Entities;
    using Domain.Interfaces.Services;
    using Generics;
    using Infrastructure.Helpers;
    using Interfaces;
    using System;
    using System.Collections.Generic;

    public class RouletteApplication : GenericApplication<Roulette>, IRouletteApplication
    {
        protected readonly IRouletteService RouletteService;


        public RouletteApplication(IGenericService<Roulette> genericService, IRouletteService rouletteService) : base(genericService)
        {
            this.RouletteService = rouletteService;
        }

        public Guid Create(Roulette roulette)
        {
            return CatchErrorHelper.Try(() => this.RouletteService.Create(roulette));
        }

        public bool OpenRoulette(Roulette roulette)
        {
            return CatchErrorHelper.Try(() => this.RouletteService.OpenRoulette(roulette));
        }
        
        public IEnumerable<Bet> CloseRoulette(Roulette roulette)
        {
            return CatchErrorHelper.Try(() => this.RouletteService.CloseRoulette(roulette));
        }
    }
}
