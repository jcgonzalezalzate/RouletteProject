namespace RouletteProject.Domain.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Generics;

    [Table("Roulette")]
    public class Roulette : GenericEntity
    {
        public RouletteState State { get; set; }
    }
}