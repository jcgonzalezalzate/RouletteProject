namespace RouletteProject.Domain.Entities.Generics
{
    using Amazon.DynamoDBv2.DataModel;
    using System;
    using System.ComponentModel.DataAnnotations;

    [DynamoDBTable("ProductCatalog")]
    public class GenericEntity
    {
        [DynamoDBHashKey]
        [Key] 
        public Guid Id { get; set; }
    }
}
