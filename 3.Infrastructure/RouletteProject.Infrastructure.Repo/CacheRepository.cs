using System.Collections.Generic;

namespace RouletteProject.Infrastructure.Repo
{
    using Domain.Entities;
    using Domain.Interfaces.Repositories;
    using Microsoft.Extensions.Caching.Distributed;
    using System;

    public class CacheRepository : ICacheRepository
    {
        protected readonly IDistributedCache CacheContext;

        public CacheRepository(IDistributedCache cacheContext)
        {
            CacheContext = cacheContext;
        }
        
        public bool Save<T>(Guid id, T entity)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(entity);
            CacheContext.SetStringAsync(id.ToString(), json);
            
            return true;
        }

        public T Get<T>(Guid id)
        {
            var json = CacheContext.GetStringAsync(id.ToString());
            if (json == null || json.Exception != null)
            {
                throw new ArgumentException($"Llave de cache inválida: {id}");
            }

            if (json.Result == null)
            {
                throw new ArgumentException($"Objeto de tipo {typeof(T).Name} no encontrado con Id {id}");
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json.Result);
        }
    }
}
