namespace RouletteProject.Domain.Entities.Enums
{
    using Swashbuckle.AspNetCore.Annotations;

    [SwaggerSchema("Defines the possible colours to bet. 1=Black, 2=Red")]
    public enum Colour
    {
        Undefined = 0,
        Black = 1,
        Red = 2
    }
}
