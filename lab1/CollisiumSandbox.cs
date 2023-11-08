using System;
using Microsoft.Extensions.FileSystemGlobbing.Internal;

namespace lab1
{
    // public interface ICollisiumSandbox
    // {
    //     bool Play(Card[] cards);
    // }
    //
    public class CollisiumSandbox 
    {
        private IPlayer _elon { get; }
        private IPlayer _mark { get; }
        
        public const int DeckSize = 36;
        private readonly CardsSplitter _splitter = new CardsSplitter();
        

        public bool Play(Card[] cards)
        {
            if (cards.Length != DeckSize) throw new InvalidDeckSizeException("GET: " + cards.Length);

            var (part1, part2) = _splitter.GetDeckForPlayers(cards);

            _mark.SetCards(part1);
            _elon.SetCards(part2);

            var elonCard = _elon.ChooseCard(_mark.SayCard());
            var markCard = _mark.ChooseCard(_elon.SayCard());
            
            return markCard.Color == elonCard.Color;
        }

        public CollisiumSandbox(IPlayer elon, IPlayer mark)
        {
            _elon = elon;
            _mark = mark;
        }
    }
} 