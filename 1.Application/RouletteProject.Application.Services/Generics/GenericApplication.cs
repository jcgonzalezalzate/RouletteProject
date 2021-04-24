﻿using System;
using RouletteProject.Domain.Interfaces.Services;
using RouletteProject.Infrastructure.Helpers;

namespace RouletteProject.Application.Services.Generics
{
    using System.Collections.Generic;
    using RouletteProject.Application.Interfaces.Generics;

    public class GenericApplication<T> : IGenericApplication<T>
    {
        public readonly IGenericService<T> GenericService;

        public GenericApplication(IGenericService<T> genericService)
        {
            GenericService = genericService;
        }

        public List<T> GetAll()
        {
            return CatchErrorHelper.Try(() => GenericService.GetAll());
        }

        public T Details(Guid id)
        {
            return CatchErrorHelper.Try(() => GenericService.Details(id));
        }

        public T Create(T entity)
        {
            return CatchErrorHelper.Try(() => GenericService.Create(entity));
        }

        public T Edit(T entity)
        {
            return CatchErrorHelper.Try(() => GenericService.Edit(entity));
        }

        public T Delete(Guid id)
        {
            return CatchErrorHelper.Try(() => GenericService.Delete(id));
        }
    }
}
