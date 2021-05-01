namespace RouletteProject.Infrastructure.Helpers
{
    using System;
    public interface ILogger
    {
        void Debug(string message);

        void Debug(string message, Exception exception);

        void Fatal(string message);

        void Fatal(string message, Exception exception);

        void Information(string message);

        void Error(string message, Exception exception);

        void Error(string message);

        void Warning(string message, Exception exception);

        void Warning(string message);
    }
}
