using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    class Program
    {
        public static ILogger GetLogger()
        {
            return new FileLogger();
        }
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<ILogger, FileLogger>();

            var configurationBuilder = new ConfigurationBuilder();

            configurationBuilder.AddJsonFile("appsettings.json", true);

            var configuration = configurationBuilder.Build();

            serviceCollection.AddSingleton<IConfiguration>(configuration);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger>();


        }

    }

    public interface ILogger
    {

    }

    public class ConsoleLogger : ILogger
    {

    }

    public class FileLogger : ILogger
    {

    }
}


