using lab1;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace exe 
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
                    services.AddScoped<Elon>();
                    services.AddScoped<Mark>();
                    services.AddScoped<ICardPickMarkStrategy, StratagyNumberOne>();
                    services.AddScoped<ICardPickElonStrategy, StratagyNumberOne>();
                });
        }
    }
}