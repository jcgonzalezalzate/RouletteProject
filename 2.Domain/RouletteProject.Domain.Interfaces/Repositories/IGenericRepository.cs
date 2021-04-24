namespace RouletteProject.Domain.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IGenericRepository<T>
    {
        List<T> GetAll();

        T Details(Expression<Func<T, bool>> expression);

        T Create(T entity);

        T Edit(T entity);

        T Delete(int id);
    }
}
