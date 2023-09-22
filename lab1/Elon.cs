using System.Collections.Generic;

namespace lab1
{
    public class Elon : IPlayer
    {
        private Card[] _cards;
        
        private readonly ICardPickStrategy _strategy;

        
        public Elon(ICardPickStrategy strategy)
        {
            _strategy = strategy;
        }
        
        public Card ChooseCard(int n) {
            return _cards[n];
        }

        public void SetCards(Card[] cards)
        {
            _cards = cards;
        }

        public int SayCard() {
            return _strategy.Pick(_cards);
        }
    }
}