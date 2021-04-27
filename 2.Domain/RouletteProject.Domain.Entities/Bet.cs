namespace RouletteProject.Domain.Entities
{
    using Amazon.DynamoDBv2.DataModel;
    using Enums;
    using Generics;
    using System;

    public class Bet : GenericEntity
    {
        [DynamoDBProperty]
        public DateTime BetDateTime { get; set; }

        [DynamoDBProperty]
        public Guid UserId { get; set; }

        [DynamoDBProperty]
        public int? NumberToBet { get; set; }

        [DynamoDBProperty]
        public Colour? ColourToBet { get; set; }

        [DynamoDBProperty]
        public decimal AmountToBet { get; set; }

        [DynamoDBProperty]
        public decimal AmountToWin { get; set; }
    }
}
