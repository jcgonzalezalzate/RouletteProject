namespace RouletteProject.Infrastructure.Repo.Generics
{
    using Domain.Entities;
    using System.Collections.Generic;

    public class RepositoryContext
    {
        public IEnumerable<Roulette> Roulettes { get; set; }
        
        public RepositoryContext()
        {
        
        }
    }
}
