using System;
using System.Linq;

namespace lab1
{
    public interface IDeckShuffler {
        void ShuffleDeck();
        Card[] GetDeck();
    }


    public class DeckShuffler : IDeckShuffler {
        private Card[] _cards;
        private readonly Random _rand = new Random();

        public void ShuffleDeck()
        {
            Card[] newCards;
            do
            {
                newCards = _cards.ToList().OrderBy(x => _rand.Next()).ToArray();
            } while (Equals(_cards, newCards));

            _cards = newCards;
        }
        
        public Card[] GetDeck()
        {
            return _cards;
        }

        public DeckShuffler()  {
            _cards = new Card[CollisiumSandbox.DeckSize];

            for (int i = 0; i < CollisiumSandbox.DeckSize; i++)
            {
                _cards[i] = new Card(i >= CollisiumSandbox.DeckSize / 2 ? CardColor.Red : CardColor.Black);
            }
        }
    }
}