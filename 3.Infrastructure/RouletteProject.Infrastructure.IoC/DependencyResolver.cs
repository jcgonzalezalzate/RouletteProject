namespace RouletteProject.Infrastructure.IoC
{
    using Amazon.DynamoDBv2;
    using Amazon.DynamoDBv2.DataModel;
    using Application.Interfaces;
    using Application.Interfaces.Generics;
    using Application.Services;
    using Application.Services.Generics;
    using Domain.Entities;
    using Domain.Entities.Configuration;
    using Domain.Interfaces.Repositories;
    using Domain.Interfaces.Services;
    using Domain.Services;
    using Domain.Services.Bet;
    using Domain.Services.Generics;
    using Microsoft.Extensions.DependencyInjection;
    using Repo;
    using Repo.Generics;
    using System;
    using System.Linq;
    using REDIS = StackExchange.Redis;

    public class DependencyResolver
    {
        public IServiceCollection SetServiceCollection(IServiceCollection services)
        {
            ResolveDynamoDb(services);
            ResolveRedis(services);

            services.AddTransient<RepositoryContext>();
            services.AddTransient(s => new BetConfiguration
            {
                MaximumRoulletteNumber = Convert.ToInt32(Environment.GetEnvironmentVariable("MAXIMUM_ROULLETTE_NUMBER")),
                MinimumRoulletteNumber = Convert.ToInt32(Environment.GetEnvironmentVariable("MINIMUM_ROULLETTE_NUMBER")),
                MultiplyingFactorByColour = Convert.ToDecimal(Environment.GetEnvironmentVariable("MULTIPLYING_FACTOR_BY_COLOUR")),
                MultiplyingFactorByNumber = Convert.ToDecimal(Environment.GetEnvironmentVariable("MULTIPLYING_FACTOR_BY_NUMBER"))
            });

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

        private void ResolveRedis(IServiceCollection services)
        {
            services.AddSingleton(provider => new RedisConfiguration
            {
                ConnectionStringTxn = Environment.GetEnvironmentVariable("REDIS_LOCALSTACK_HOSTNAME")
            });

            services.AddSingleton(CreateRedisServerForManagement);
            services.AddStackExchangeRedisCache(opt =>
            {
                var redisConfig = services.BuildServiceProvider().GetService<RedisConfiguration>();
                opt.Configuration = redisConfig.ConnectionStringTxn;
            });
        }

        private void ResolveDynamoDb(IServiceCollection services)
        {
            services.AddSingleton<IAmazonDynamoDB>(sp =>
            {
                var clientConfig = new AmazonDynamoDBConfig
                {
                    ServiceURL = Environment.GetEnvironmentVariable("DYNAMO_LOCALSTACK_HOSTNAME")
                };

                return new AmazonDynamoDBClient(clientConfig);
            });

            services.AddTransient<IDynamoDBContext, DynamoDBContext>();
        }

        private REDIS.IServer CreateRedisServerForManagement(IServiceProvider provider)
        {
            var redisConfig = provider.GetService<RedisConfiguration>();
            var cnstringAdmin = redisConfig.ConnectionStringAdmin;
            var redis = REDIS.ConnectionMultiplexer.Connect(cnstringAdmin);
            var firstEndPoint = redis.GetEndPoints().FirstOrDefault();

            if (firstEndPoint == null)
            {
                throw new ArgumentException("The endpoints collection was empty. Could not get an end point from Redis connection multiplexer.");
            }

            return redis.GetServer(firstEndPoint);
        }
    }
}
