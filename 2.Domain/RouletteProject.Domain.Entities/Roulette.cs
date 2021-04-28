using System.Collections.Generic;

namespace RouletteProject.Domain.Entities
{
    using Amazon.DynamoDBv2.DataModel;
    using Enums;
    using Generics;
    using System;

    [DynamoDBTable("Roulette")]
    public class Roulette : GenericEntity
    {
        public DateTime CreationDateTime { get; set; }

        public DateTime OpenDateTime { get; set; }

        public DateTime CloseDateTime { get; set; }

        public RouletteState State { get; set; }

        public int WinningNumber { get; set; }

        public Colour WinningColour { get; set; }

        public List<Bet> Bets { get; set; }
    }
}