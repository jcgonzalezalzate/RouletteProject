using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RouletteProject.ApiRest.Models;
using RouletteProject.Infrastructure.IoC;
using System;
using System.Linq;
using REDIS = StackExchange.Redis;

namespace RouletteProject.ApiRest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var dynamoDbConfig = Configuration.GetSection("DynamoDb");
            var runLocalDynamoDb = dynamoDbConfig.GetValue<bool>("LocalMode");

            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            
            if (runLocalDynamoDb)
            {
                services.AddSingleton<IAmazonDynamoDB>(sp =>
                {
                    var clientConfig = new AmazonDynamoDBConfig { ServiceURL = dynamoDbConfig.GetValue<string>("LocalServiceUrl") };
                    return new AmazonDynamoDBClient(clientConfig);
                });
            }
            else
            {
                services.AddAWSService<IAmazonDynamoDB>();
            }

            services.AddTransient<IDynamoDBContext, DynamoDBContext>();

            services.AddSingleton(provider => new RedisConfiguration
            {
                ConnectionStringTxn = Configuration.GetValue<string>("redisCnstring")
            });
            services.AddSingleton<REDIS.IServer>(CreateRedisServerForManagement);

            services.AddStackExchangeRedisCache(opt =>
            {
                var redisConfig = services.BuildServiceProvider().GetService<RedisConfiguration>();
                opt.Configuration = redisConfig.ConnectionStringTxn;
            });

            new DependencyResolver().SetServiceCollection(services);

            services.AddControllers();

            services.AddSwaggerGen(c => { c.EnableAnnotations(); });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Roulette API");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private REDIS.IServer CreateRedisServerForManagement(IServiceProvider provider)
        {
            var redisConfig = provider.GetService<RedisConfiguration>();
            var cnstringAdmin = redisConfig.ConnectionStringAdmin;
            //You need allowAdmin=true to call methods .FlushDatabase and .Keys()
            //https://stackexchange.github.io/StackExchange.Redis/Basics.html
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
