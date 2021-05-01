namespace RouletteProject.Domain.Entities.DTO
{
    public class GenericResponse<T>
    {
        public T Result { get; set; }

        public bool HasErrors { get; set; }

        public string[] Errors { get; set; }
    }
}
