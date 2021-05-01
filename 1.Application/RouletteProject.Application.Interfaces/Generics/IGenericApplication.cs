
namespace RouletteProject.Application.Interfaces.Generics
{
    using Domain.Entities.DTO;
    using System;
    using System.Collections.Generic;

    public interface IGenericApplication<T>
    {
        GenericResponse<List<T>> GetAll();

        GenericResponse<T> Details(Guid id);

        GenericResponse<T> Create(T entity);

        GenericResponse<T> Edit(T entity);

        GenericResponse<bool> Delete(Guid id);
    }
}
