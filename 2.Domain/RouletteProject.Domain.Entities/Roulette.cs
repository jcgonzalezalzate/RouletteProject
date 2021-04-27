namespace RouletteProject.Domain.Entities
{
    using Amazon.DynamoDBv2.DataModel;
    using Enums;
    using Generics;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class Roulette : GenericEntity
    {
        [DynamoDBProperty]
        public DateTime OpenDateTime { get; set; }

        [DynamoDBProperty]
        public DateTime CloseDateTime { get; set; }

        [DynamoDBProperty]
        public RouletteState State { get; set; }

        [DynamoDBProperty]
        public int WinningNumber { get; set; }

        [DynamoDBProperty]
        public Colour WinningColour { get; set; }
    }
}