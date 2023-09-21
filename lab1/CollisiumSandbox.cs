
using System;
using System.Linq;

namespace lab1
{
    public class CollisiumSandbox
    {
        private readonly Elon _elon;
        private readonly Mark _mark;

        public bool Play(Card[] cards)
        {
            if (cards.Length != 36) throw new Exception();

            _mark.SetCards(cards.ToList().GetRange(0, 18).ToArray());
            _elon.SetCards(cards.ToList().GetRange(18, 18).ToArray());
            
            return _elon.ChooseCard(_mark.SayCard()).Color == _mark.ChooseCard(_elon.SayCard()).Color;
        }

        public CollisiumSandbox(Elon elon, Mark mark)
        {
            _elon = elon;
            _mark = mark;
        }
    }
} 