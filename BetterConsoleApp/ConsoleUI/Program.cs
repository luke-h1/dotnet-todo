using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

// DI, serilog & Settings


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

                Log.Logger.Information("Application Starting");
                var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => 
                {

                }).UseSerilog().Build();
        }
        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                  .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                  .AddEnvironmentVariables();

        }
    }
    public class GreetingService 
    {
        private readonly ILogger<GreetingService> _log; 
        public GreetingService(ILogger<GreetingService> log, IConfiguration config)
        {
            _log = log; 
        }
        public void Run() 
        {
            for (var i = 0; i < 10; i++)
            {
                
            }
        }
    }
}
