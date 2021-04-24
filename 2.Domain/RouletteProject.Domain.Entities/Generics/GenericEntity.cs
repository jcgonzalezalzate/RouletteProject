using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RouletteProject.Domain.Entities.Generics
{
    public class GenericEntity
    {
        [Key] 
        public Guid Id { get; set; }
    }
}
