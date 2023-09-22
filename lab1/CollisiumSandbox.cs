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
            if (cards.Length != DeckSize) throw new Exception();

            var (part1, part2) = _splitter.GetDeckForPlayers(cards);

            _mark.SetCards(part1);
            _elon.SetCards(part2);
            
            return _elon.ChooseCard(_mark.SayCard()).Color == _mark.ChooseCard(_elon.SayCard()).Color;
        }

        public CollisiumSandbox(Elon elon, Mark mark)
        {
            _elon = elon;
            _mark = mark;
        }
    }
} 