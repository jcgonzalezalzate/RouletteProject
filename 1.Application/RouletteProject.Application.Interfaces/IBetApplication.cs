namespace RouletteProject.Application.Interfaces
{
    using Domain.Entities.DTO;
    using Domain.Entities;
    using Generics;
    using System;

    public interface IBetApplication : IGenericApplication<Bet>
    {
        GenericResponse<Bet> GetABet(Guid id);

        GenericResponse<bool> SaveABet(Bet bet);
    }
}
