using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

// github.com/mvcdev/DEvil
// mock

namespace lab1
{
    public class CollisiumExperimentWorker : IHostedService
    {
        private readonly int _count = 1000000;
        
        private readonly IDeckShuffler _deckShuffler;
        private readonly CollisiumSandbox _sandbox;

        public CollisiumExperimentWorker(CollisiumSandbox sandbox, IDeckShuffler deckShuffler)
        {
            _sandbox = sandbox;
            _deckShuffler = deckShuffler;
        }
        
        public void Play()
        {
            int win = 0;
            
            for (int i = 0; i < _count; i++) {
                _deckShuffler.ShuffleDeck();
                win += _sandbox.Play(_deckShuffler.GetDeck()) ? 1 : 0;
            }
            
            Console.WriteLine("Wins : " + (double) win / _count * 100 + "%"); 
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(Play, cancellationToken);
            return Task.CompletedTask;
            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        
    }
}
