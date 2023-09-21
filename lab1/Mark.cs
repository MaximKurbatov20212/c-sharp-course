
namespace lab1
{
    public class Mark : IPlayer {
        private Card[] _cards;
        
        private readonly ICardPickStrategy _strategy = new ElonStrategy();

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

    };
}