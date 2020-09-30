using System;
using System.IO;

namespace Interface
{
        class Program
    {
        public static ILogger GetLogger()
        {
            return new FileLogger(); // i tylko tutaj zamieniamy FileLogger na ConsoleLogger
        }
        static void Main(string[] args)
        {
            var logger = GetLogger();

            logger.LogMessage("wiadomość");
            logger.LogMessage("wiadomość krytyczna!!!!", LogLevel.Critical);

            //ILogger logger2 = new FileLogger();                 // druga wersja metody GetLogger   
            //logger2.LogMessage("elo!", LogLevel.Critical);

            SomeFunction(new FileLogger()); // zamiast Ilogger wpisujemy instancję klasy implementującej Ilogger'a
        }
        private static void SomeFunction (ILogger logger)
        {

        }
    }

    public interface ILogger
    {
        LogLevel logLevel { get; set; }
        void LogMessage(string message, LogLevel logLevel = LogLevel.Debug);
    }

    public class ConsoleLogger : ILogger
    {
        public LogLevel logLevel { get; set; } = LogLevel.Verbose;

        public void LogMessage(string message, LogLevel logLevel = LogLevel.Debug)
        {
            if (this.logLevel > logLevel)
                return;
            Console.WriteLine(message);
        }
    }

    public class FileLogger : ILogger
    {
        public LogLevel logLevel { get; set; } = LogLevel.Critical;
        public void LogMessage(string message, LogLevel logLevel = LogLevel.Debug)
        {
            if (this.logLevel > logLevel)
                return;
            
            File.WriteAllText("logs.txt", message);
        }
    }

    public enum LogLevel
    {
        Verbose = 0,
        Debug = 1, 
        Critical = 2
    }
}
