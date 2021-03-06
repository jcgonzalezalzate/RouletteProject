namespace RouletteProject.Infrastructure.Repo.Generics
{
    using Amazon.DynamoDBv2;
    using Amazon.DynamoDBv2.DataModel;
    using Domain.Entities;
    using System.Collections.Generic;

    public class RepositoryContext : DynamoDBContext
    {
        public IEnumerable<Roulette> Roulettes { get; set; }

        public IEnumerable<Bet> Bets { get; set; }

        public RepositoryContext(IAmazonDynamoDB client) : base(client)
        {
        
        }
    }
}
