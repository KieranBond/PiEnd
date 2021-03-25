using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Topshelf;

namespace PiEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddConsole();
            });

            ILogger logger = loggerFactory.CreateLogger<Program>();

            HostFactory.Run(configure =>
            {
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                configure.Service<ApiStartup>(service =>
               {
                   service.ConstructUsing(s => new ApiStartup(configuration, logger));
                   service.WhenStarted(s => s.Start());
                   service.WhenStopped(s => s.Stop());
               });
            });
        }
    }
}
