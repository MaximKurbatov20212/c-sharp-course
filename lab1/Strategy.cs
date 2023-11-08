
using System.Collections.Generic;

namespace lab1
{
    public interface ICardPickStrategy
    {
        int Pick(Card[] cards);
    }
    
    public interface ICardPickMarkStrategy : ICardPickStrategy {}
    
    public interface ICardPickElonStrategy : ICardPickStrategy {}

    public class PickFirstRedCardStrategy : ICardPickElonStrategy, ICardPickMarkStrategy
    {
        public int Pick(Card[] cards)
        {
            if (cards.Length != CollisiumSandbox.DeckSize / 2) throw new InvalidDeckSizeException("GET: " + cards.Length);
            
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i].Color == CardColor.Red) {
                    return i;
                }
            }
            return 0;
        }
    }
    
    public class PickFirstBlackCardStrategy : ICardPickElonStrategy, ICardPickMarkStrategy
    {
        public int Pick(Card[] cards)
        {
            if (cards.Length != CollisiumSandbox.DeckSize / 2) throw new InvalidDeckSizeException("GET: " + cards.Length);
            
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i].Color == CardColor.Black) {
                    return i;
                }
            }
            return 0;
        }
    }
    
    public class StratagyNumberOne: ICardPickElonStrategy, ICardPickMarkStrategy
    {
        public int Pick(Card[] list)
        {   
            var x = 0;
            while (true)
            {
                if (list[x].ToString() == "🔴" || x == list.Length - 1) return x;
                x++;
            }
        }
    }
}
