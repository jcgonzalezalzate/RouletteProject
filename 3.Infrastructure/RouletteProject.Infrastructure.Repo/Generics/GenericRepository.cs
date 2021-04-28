namespace RouletteProject.Infrastructure.Repo.Generics
{
    using Amazon.DynamoDBv2.DataModel;
    using Domain.Interfaces.Repositories;
    using RouletteProject.Domain.Entities.Generics;
    using System;
    using System.Collections.Generic;

    public class GenericRepository<T> : IGenericRepository<T> where T : GenericEntity
    {
        protected readonly RepositoryContext RepositoryContext;

        public GenericRepository(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public List<T> GetAll()
        {
            var conditions = new List<ScanCondition>();
            var result = RepositoryContext.ScanAsync<T>(conditions);
            
            return ControlTaskError(() => result.GetRemainingAsync()).Result;
        }

        public T Details(Guid id)
        {
            var result = RepositoryContext.LoadAsync<T>(id, new DynamoDBContextConfig { ConsistentRead = true });
            return result.Result;
        }

        public T Create(T entity)
        {
            ControlTaskError(() => RepositoryContext.SaveAsync(entity));
            return entity;
        }

        public T Edit(T entity)
        {
            ControlTaskError(() => RepositoryContext.SaveAsync(entity));
            return entity;
        }

        public bool Delete(Guid id)
        {
            var result = ControlTaskError(() => RepositoryContext.DeleteAsync<T>(id));
            return result.IsCompleted;
        }

        public TP ControlTaskError<TP>(Func<TP> action)
        {
            dynamic result = action();
            if (result.Exception != null)
            {
                throw result.Exception;
            }

            return result;
        }
    }
}
