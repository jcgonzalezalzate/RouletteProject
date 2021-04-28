namespace RouletteProject.Domain.Interfaces.Services
{
    using System;
    using System.Collections.Generic;

    public interface IGenericService<T>
    {
        List<T> GetAll();

        T Details(Guid id);

        T Create(T entity);

        T Edit(T entity);

        bool Delete(Guid id);
    }
}
