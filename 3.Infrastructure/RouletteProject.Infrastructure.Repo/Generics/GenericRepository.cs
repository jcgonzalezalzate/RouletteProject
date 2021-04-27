using Amazon.DynamoDBv2.DataModel;

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
            var conditions = new List<ScanCondition>();
            var result = this.RepositoryContext.ScanAsync<T>(conditions).GetRemainingAsync();

            return result.Result;
        }

        public T Details(Guid id)
        {
            var result = this.RepositoryContext.LoadAsync<T>(id, new DynamoDBContextConfig { ConsistentRead = true });
            return result.Result;
        }

        public T Create(T entity)
        {
            this.RepositoryContext.SaveAsync(entity);
            return entity;
        }

        public T Edit(T entity)
        {
            this.RepositoryContext.SaveAsync(entity);
            return entity;
        }

        public bool Delete(Guid id)
        {
            var result = this.RepositoryContext.DeleteAsync<T>(id);
            return result.IsCompleted;
        }
    }
}
