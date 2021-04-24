namespace RouletteProject.Infrastructure.Repo.Generics
{
    using Domain.Interfaces.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using RouletteProject.Domain.Entities.Generics;

    public class GenericRepository<T> : IGenericRepository<T> where T : GenericEntity
    {
        public RepositoryContext RepositoryContext { get; set; }

        public GenericRepository(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public List<T> GetAll()
        {
            return null;
        }

        public T Details(Expression<Func<T, bool>> expression)
        {
            return null;
        }

        public T Create(T entity)
        {
            return entity;
        }

        public T Edit(T entity)
        {
            return entity;
        }

        public T Delete(int id)
        {
            return null;
        }
    }
}
