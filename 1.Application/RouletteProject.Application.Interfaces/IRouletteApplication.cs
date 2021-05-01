
namespace RouletteProject.Application.Interfaces
{
    using Domain.Entities;
    using Domain.Entities.DTO;
    using Generics;
    using System;

    public interface IRouletteApplication : IGenericApplication<Roulette>
    {
        GenericResponse<Guid> Create();
        
        GenericResponse<bool> OpenRoulette(Guid id);

        GenericResponse<Roulette> CloseRoulette(Guid id);
    }
}
