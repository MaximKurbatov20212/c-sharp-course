using System.Collections.Generic;

namespace lab1
{
    public class Elon : IPlayer
    {
        private Card[] _cards;
        
        private readonly ICardPickStrategy _strategy = new ElonStrategy();

        public Card ChooseCard(int n) {
            return _cards[n];
        }

        // public Elon(Card[] cards)
        // {
        //     _cards = cards;
        // }

        public void SetCards(Card[] cards)
        {
            this._cards = cards;
        }

        public int SayCard() {
            return _strategy.Pick(_cards);
        }
    }
}