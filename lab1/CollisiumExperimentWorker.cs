using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace lab1
{
    public class CollisiumExperimentWorker : IHostedService
    {
        private readonly int _count = 1000000;
        private DeckShuffler _deckShuffler = new DeckShuffler();
        
        public void Play()
        {
            int win = 0;
            
            for (int i = 0; i < _count; i++) {
                CollisiumSandbox game = new CollisiumSandbox(new Elon(), new Mark());
                win += game.Play(_deckShuffler.GetDeck()) ? 1 : 0;
            }
            Console.WriteLine((double) win / _count * 100 + "%"); 
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Play();
            return Task.CompletedTask;
            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}