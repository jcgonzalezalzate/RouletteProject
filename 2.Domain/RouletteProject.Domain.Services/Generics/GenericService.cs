namespace RouletteProject.Domain.Services.Generics
{
    using Entities.Generics;
    using Interfaces.Repositories;
    using Interfaces.Services;
    using System;
    using System.Collections.Generic;

    public class GenericService<T> : IGenericService<T> where T : GenericEntity
    {
        public IGenericRepository<T> GenericRepository { get; set; }

        public GenericService(IGenericRepository<T> genericRepository)
        {
            GenericRepository = genericRepository;
        }

        public virtual List<T> GetAll()
        {
            return GenericRepository.GetAll();
        }

        public virtual T Details(Guid id)
        {
            return GenericRepository.Details(id);
        }

        public virtual T Create(T entity)
        {
            return GenericRepository.Create(entity);
        }

        public virtual T Edit(T entity)
        {
            return GenericRepository.Edit(entity);
        }

        public virtual bool Delete(Guid id)
        {
            return GenericRepository.Delete(id);
        }
    }
}
