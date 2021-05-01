namespace RouletteProject.Domain.Entities.Enums
{
    using Swashbuckle.AspNetCore.Annotations;

    [SwaggerSchema("Defines the possible roulette states. 0=Created, 1=Closed, 2=Opened")]
    public enum RouletteState
    {
        Created = 0,
        Closed = 1,
        Opened = 2
    }
}