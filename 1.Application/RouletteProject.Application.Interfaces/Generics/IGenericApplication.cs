namespace RouletteProject.Application.Interfaces.Generics
{
    using System.Collections.Generic;

    public interface IGenericApplication<T>
    {
        List<T> GetAll();

        T Details(int id);

        T Create(T entity);

        T Edit(T entity);

        T Delete(int id);
    }
}
