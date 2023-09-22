namespace lab1
{
    public interface ICardPickStrategy
    {
        int Pick(Card[] cards);
    }

    public class PickFirstRedCardStrategy : ICardPickStrategy
    {
        public int Pick(Card[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i].Color == CardColor.Red) {
                    return i;
                }
            }
            return 0;
        }
    }
}