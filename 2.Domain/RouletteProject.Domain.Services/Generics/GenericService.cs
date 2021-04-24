using System;
using System.Collections.Generic;
using RouletteProject.Domain.Entities.Generics;
using RouletteProject.Domain.Interfaces.Repositories;
using RouletteProject.Domain.Interfaces.Services;

namespace RouletteProject.Domain.Services.Generics
{
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
            return GenericRepository.Details(i => i.Id == id);
        }

        public virtual T Create(T entity)
        {
            return GenericRepository.Create(entity);
        }

        public virtual T Edit(T entity)
        {
            return GenericRepository.Edit(entity);
        }

        public virtual T Delete(Guid id)
        {
            return GenericRepository.Delete(id);
        }
    }
}
