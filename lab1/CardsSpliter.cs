using System.Linq;

namespace lab1
{
    public class CardsSplitter
    {
        public (Card[], Card[]) GetDeckForPlayers(Card[] cards)
        {
            if (cards.Length != CollisiumSandbox.DeckSize) throw new InvalidDeckSizeException("GET: " + cards.Length);

            return (cards.ToList().GetRange(0, CollisiumSandbox.DeckSize / 2).ToArray(),
                cards.ToList().GetRange(CollisiumSandbox.DeckSize / 2, CollisiumSandbox.DeckSize / 2).ToArray());
        }
    }
}