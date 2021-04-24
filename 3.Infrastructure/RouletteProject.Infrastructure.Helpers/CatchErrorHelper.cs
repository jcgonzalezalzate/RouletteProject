namespace RouletteProject.Infrastructure.Helpers
{
    using System;

    public static class CatchErrorHelper
    {
        public static T Try<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
