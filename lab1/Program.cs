using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace lab1
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)        	
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<CollisiumExperimentWorker>();
                    services.AddScoped<CollisiumSandbox>();
                    services.AddScoped<IDeckShuffler, DeckShuffler>();
                    services.AddScoped<IPlayer, Elon>();
                    services.AddScoped<IPlayer, Mark>();
                    services.AddScoped<ICardPickStrategy, MarkStrategy>();
                    services.AddScoped<ICardPickStrategy, ElonStrategy>();
                });
        }
    }
}