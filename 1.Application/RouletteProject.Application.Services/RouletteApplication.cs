using RouletteProject.Domain.Interfaces.Services;

namespace RouletteProject.Application.Services
{
    using Domain.Entities;
    using Generics;
    using Interfaces;

    public class RouletteApplication : GenericApplication<Roulette>, IRouletteApplication
    {
        public RouletteApplication(IGenericService<Roulette> genericService) : base(genericService)
        {
        }
    }
}
