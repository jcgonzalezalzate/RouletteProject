namespace RouletteProject.Domain.Interfaces.Services
{
    using System.Collections.Generic;

    public interface IGenericService<T>
    {
        List<T> GetAll();

        T Details(int id);

        T Create(T entity);

        T Edit(T entity);

        T Delete(int id);
    }
}
