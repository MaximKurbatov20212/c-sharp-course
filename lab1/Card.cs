namespace lab1
{
    public class Card
    {
        public readonly CardColor Color;

        public Card(CardColor color)
        {
            Color = color;
        }
        
        public override string ToString()
        {
            return Color == CardColor.Black ? "♠️" : "♦️";
        }
    }
}