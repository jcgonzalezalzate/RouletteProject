namespace RouletteProject.Application.Interfaces.Generics
{
    using System;
    using System.Collections.Generic;

    public interface IGenericApplication<T>
    {
        List<T> GetAll();

        T Details(Guid id);

        T Create(T entity);

        T Edit(T entity);

        bool Delete(Guid id);
    }
}
