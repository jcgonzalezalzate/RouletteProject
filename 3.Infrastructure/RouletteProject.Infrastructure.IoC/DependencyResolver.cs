using RouletteProject.Domain.Services.Bet;

namespace RouletteProject.Infrastructure.IoC
{
    using Application.Interfaces;
    using Application.Interfaces.Generics;
    using Application.Services;
    using Application.Services.Generics;
    using Domain.Entities;
    using Domain.Interfaces.Repositories;
    using Domain.Interfaces.Services;
    using Domain.Services;
    using Domain.Services.Generics;
    using Microsoft.Extensions.DependencyInjection;
    using Repo;
    using Repo.Generics;

    public class DependencyResolver
    {
        public IServiceCollection SetServiceCollection(IServiceCollection services)
        {
            services.AddTransient<RepositoryContext>();
            services.AddTransient<IDynamoRepository, DynamoRepository>();
            services.AddTransient<ICacheRepository, CacheRepository>();

            services.AddTransient<IRouletteApplication, RouletteApplication>();
            services.AddTransient<IRouletteService, RouletteService>();
            services.AddTransient<IGenericRepository<Roulette>, GenericRepository<Roulette>>();
            services.AddTransient<IGenericService<Roulette>, GenericService<Roulette>>();
            services.AddTransient<IGenericApplication<Roulette>, GenericApplication<Roulette>>();
            
            services.AddTransient<IBetApplication, BetApplication>();
            services.AddTransient<IBetService, BetService>();
            services.AddTransient<IGenericRepository<Bet>, GenericRepository<Bet>>();
            services.AddTransient<IGenericService<Bet>, GenericService<Bet>>();
            services.AddTransient<IGenericApplication<Bet>, GenericApplication<Bet>>();

            return services;
        }
    }
}
