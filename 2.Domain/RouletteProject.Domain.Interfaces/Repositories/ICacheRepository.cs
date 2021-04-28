namespace RouletteProject.Domain.Interfaces.Repositories
{
    using Entities;
    using System;
    using System.Collections.Generic;

    public interface ICacheRepository
    {
        T Get<T>(Guid id);

        bool Save<T>(Guid id, T entity);
    }
}
