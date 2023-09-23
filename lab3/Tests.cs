using System.Linq;
using lab1;
using NUnit.Framework;

namespace lab3
{
    [TestFixture]
    public class Tests
    {
        readonly Card[] loseDeck =
        {
            new Card(CardColor.Red), new Card(CardColor.Red), new Card(CardColor.Red),
            new Card(CardColor.Red), new Card(CardColor.Red), new Card(CardColor.Red),
            new Card(CardColor.Red), new Card(CardColor.Red), new Card(CardColor.Red),
            new Card(CardColor.Red), new Card(CardColor.Red), new Card(CardColor.Red),
            new Card(CardColor.Red), new Card(CardColor.Red), new Card(CardColor.Red),
            new Card(CardColor.Red), new Card(CardColor.Red), new Card(CardColor.Red),
            
            new Card(CardColor.Black), new Card(CardColor.Black), new Card(CardColor.Black),
            new Card(CardColor.Black), new Card(CardColor.Black), new Card(CardColor.Black),
            new Card(CardColor.Black), new Card(CardColor.Black), new Card(CardColor.Black),
            new Card(CardColor.Black), new Card(CardColor.Black), new Card(CardColor.Black),
            new Card(CardColor.Black), new Card(CardColor.Black), new Card(CardColor.Black),
            new Card(CardColor.Black), new Card(CardColor.Black), new Card(CardColor.Black)
        };

        private readonly Card[] winDeck =
        {
            new Card(CardColor.Red), new Card(CardColor.Black), new Card(CardColor.Red),
            new Card(CardColor.Red), new Card(CardColor.Red), new Card(CardColor.Red),
            new Card(CardColor.Red), new Card(CardColor.Red), new Card(CardColor.Red),
            new Card(CardColor.Red), new Card(CardColor.Red), new Card(CardColor.Red),
            new Card(CardColor.Red), new Card(CardColor.Red), new Card(CardColor.Red),
            new Card(CardColor.Red), new Card(CardColor.Red), new Card(CardColor.Red),

            new Card(CardColor.Red), new Card(CardColor.Black), new Card(CardColor.Black),
            new Card(CardColor.Black), new Card(CardColor.Black), new Card(CardColor.Black),
            new Card(CardColor.Black), new Card(CardColor.Black), new Card(CardColor.Black),
            new Card(CardColor.Black), new Card(CardColor.Black), new Card(CardColor.Black),
            new Card(CardColor.Black), new Card(CardColor.Black), new Card(CardColor.Black),
            new Card(CardColor.Black), new Card(CardColor.Black), new Card(CardColor.Black)
        };
        

        [Test]
        public void CorrectAllCardsCount()
        {
            DeckShuffler deckShuffler = new DeckShuffler();
            Assert.AreEqual(deckShuffler.GetDeck().Length, CollisiumSandbox.DeckSize);
        }

        [TestCase(CardColor.Black)]
        [TestCase(CardColor.Red)]
        public void CorrectCardsCount(CardColor color)
        {
            DeckShuffler deckShuffler = new DeckShuffler();
            Assert.AreEqual(deckShuffler.GetDeck().ToList().FindAll(e => e.Color == color).Count,
                CollisiumSandbox.DeckSize / 2);
        }
        
        [Test]
        public void CorrectDeckShuffle()
        {
            DeckShuffler deckShuffler = new DeckShuffler();
            Card[] notMixedDeck = deckShuffler.GetDeck();
            
            deckShuffler.ShuffleDeck();
            
            Card[] mixedDeck = deckShuffler.GetDeck();
            
            Assert.AreNotEqual(mixedDeck, notMixedDeck);
        }
        
        
        [Test]
        public void TestCorrectnessFirstPartDeckFromDeckSplitter()
        {
            CardsSplitter splitter = new CardsSplitter();
            
            Assert.AreEqual(
                loseDeck.ToList().GetRange(0, CollisiumSandbox.DeckSize / 2).ToArray(),
                splitter.GetDeckForPlayers(loseDeck).Item1);
        }

        [Test]
        public void TestCorrectnessSecondPartDeckFromDeckSplitter()
        {
            CardsSplitter splitter = new CardsSplitter();

            Assert.AreEqual(
                loseDeck.ToList().GetRange(CollisiumSandbox.DeckSize / 2, CollisiumSandbox.DeckSize / 2).ToArray(),
                splitter.GetDeckForPlayers(loseDeck).Item2);
        }
        
        [Test]
        public void NoRedCardInDeckTest()
        {
            PickFirstRedCardStrategy strategy = new PickFirstRedCardStrategy();
            strategy.Pick(loseDeck);
        }

        [Test]
        public void MarkAndElonLoseTest()
        {
            CollisiumSandbox game = new CollisiumSandbox(new Elon(new PickFirstRedCardStrategy()), new Mark(new PickFirstRedCardStrategy()));
            
            bool win = game.Play(loseDeck);
            Assert.False(win);
        }
        
        [Test]
        public void MarkAndElonWinTest()
        {
            CollisiumSandbox game = new CollisiumSandbox(new Elon(new PickFirstRedCardStrategy()), new Mark(new PickFirstRedCardStrategy()));
            
            bool win = game.Play(winDeck);
            Assert.True(win);
        }
    }
}
