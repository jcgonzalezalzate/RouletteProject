namespace RouletteProject.Infrastructure.Helpers
{
    using Domain.Entities.DTO;
    using System;

    public static class CatchErrorHelper
    {
        public static GenericResponse<T> Try<T>(Func<T> action)
        {
            var response = new GenericResponse<T>();
            try
            {
                response.Result = action();
            }
            catch (Exception ex)
            {
                response.HasErrors = true;
                response.Errors = ex.Message.Split('|');
            }

            return response;
        }
    }
}
