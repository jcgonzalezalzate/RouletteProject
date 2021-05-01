namespace RouletteProject.Infrastructure.Helpers
{
    using Serilog;
    using System;

    public class Logger : ILogger
    {
        private static readonly ILogger LoggerInstance = new Logger();

        static Logger()
        {
        }

        private readonly Serilog.ILogger log = Log.ForContext(typeof(Logger));

        public static ILogger Current
        {
            get { return LoggerInstance; }
        }

        public void Debug(string message)
        {
            log.Debug(message);
        }

        public void Debug(string message, Exception exception)
        {
            log.Debug(message, exception);
        }

        public void Error(string message, Exception exception)
        {
            log.Error(message + ". \nException {@Exception}", exception);
        }

        public void Error(string message)
        {
            log.Error(message);
        }

        public void Fatal(string message)
        {
            log.Fatal(message);
        }

        public void Fatal(string message, Exception exception)
        {
            log.Fatal(message, exception);
        }

        public void Information(string message)
        {
            log.Information(message);
        }

        public void Warning(string message, Exception exception)
        {
            log.Warning(message, exception);
        }

        public void Warning(string message)
        {
            log.Warning(message);
        }
    }
}