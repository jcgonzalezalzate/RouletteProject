using Microsoft.Extensions.DependencyInjection;
using RouletteProject.Application.Interfaces;
using RouletteProject.Application.Interfaces.Generics;
using RouletteProject.Application.Services;
using RouletteProject.Application.Services.Generics;
using RouletteProject.Domain.Entities;
using RouletteProject.Domain.Interfaces.Repositories;
using RouletteProject.Domain.Interfaces.Services;
using RouletteProject.Domain.Services.Generics;
using RouletteProject.Infrastructure.Repo;
using RouletteProject.Infrastructure.Repo.Generics;

namespace RouletteProject.Infrastructure.IoC
{
    public class DependencyResolver
    {
        public IServiceCollection SetServiceCollection(IServiceCollection services)
        {

            services.AddTransient<RepositoryContext>();
            services.AddTransient<IRouletteApplication, RouletteApplication>();
            services.AddTransient<IRouletteRepository, RouletteRepository>();
            services.AddTransient<IGenericRepository<Roulette>, GenericRepository<Roulette>>();
            services.AddTransient<IGenericService<Roulette>, GenericService<Roulette>>();
            services.AddTransient<IGenericApplication<Roulette>, GenericApplication<Roulette>>();


            return services;
        }
    }
}
