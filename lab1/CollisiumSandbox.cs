using System;

namespace lab1
{
    public class CollisiumSandbox
    {
        private readonly Elon _elon;
        private readonly Mark _mark;
        public const int DeckSize = 36;
        private readonly CardsSplitter _splitter = new CardsSplitter();
        

        public bool Play(Card[] cards)
        {
            if (cards.Length != DeckSize) throw new InvalidDeckSizeException();

            var (part1, part2) = _splitter.GetDeckForPlayers(cards);

            _mark.SetCards(part1);
            _elon.SetCards(part2);

            var elonCard = _elon.ChooseCard(_mark.SayCard());
            var markCard = _mark.ChooseCard(_elon.SayCard());
            
            return markCard.Color == elonCard.Color;
        }

        public CollisiumSandbox(Elon elon, Mark mark)
        {
            _elon = elon;
            _mark = mark;
        }
    }
} 