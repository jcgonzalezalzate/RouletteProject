namespace RouletteProject.Domain.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;

    public interface IGenericRepository<T>
    {
        List<T> GetAll();

        T Details(Guid id);

        T Create(T entity);

        T Edit(T entity);

        bool Delete(Guid id);
    }
}
