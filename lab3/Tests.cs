using System.Linq;
using lab1;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using Moq;

namespace lab3
{
    [TestFixture]
    public class Tests
    {
        private readonly Card[] loseDeck =
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


        // количество карт 36
        [Test]
        public void CorrectAllCardsCount()
        {
            DeckShuffler deckShuffler = new DeckShuffler();
            Assert.AreEqual(deckShuffler.GetDeck().Length, CollisiumSandbox.DeckSize);
        }

        // количество кар каждого цвета 18
        [TestCase(CardColor.Black)]
        [TestCase(CardColor.Red)]
        public void CorrectCardsCount(CardColor color)
        {
            DeckShuffler deckShuffler = new DeckShuffler();
            Assert.AreEqual(deckShuffler.GetDeck().ToList().FindAll(e => e.Color == color).Count,
                CollisiumSandbox.DeckSize / 2);
        }

        // шаффлер меняет колоду
        [Test]
        public void CorrectDeckShuffle()
        {
            DeckShuffler deckShuffler = new DeckShuffler();
            Card[] notMixedDeck = deckShuffler.GetDeck();

            deckShuffler.ShuffleDeck();

            Card[] mixedDeck = deckShuffler.GetDeck();

            Assert.AreNotEqual(mixedDeck, notMixedDeck);
        }


        // правильное разделение колоды
        [Test]
        public void TestCorrectnessFirstPartDeckFromDeckSplitter()
        {
            CardsSplitter splitter = new CardsSplitter();

            Assert.AreEqual(
                loseDeck.ToList().GetRange(0, CollisiumSandbox.DeckSize / 2).ToArray(),
                splitter.GetDeckForPlayers(loseDeck).Item1);
        }

        // правильное разделение колоды
        [Test]
        public void TestCorrectnessSecondPartDeckFromDeckSplitter()
        {
            CardsSplitter splitter = new CardsSplitter();

            Assert.AreEqual(
                loseDeck.ToList().GetRange(CollisiumSandbox.DeckSize / 2, CollisiumSandbox.DeckSize / 2).ToArray(),
                splitter.GetDeckForPlayers(loseDeck).Item2);
        }

        // как работает стратегия выбора первой карасной карты, если нет красных карт?
        [Test]
        public void NoRedCardInDeckTest()
        {
            PickFirstRedCardStrategy strategy = new PickFirstRedCardStrategy();
            int cardNumber = strategy.Pick(loseDeck.ToList().GetRange(0, CollisiumSandbox.DeckSize / 2).ToArray());

            Assert.True(cardNumber >= 0 && cardNumber < CollisiumSandbox.DeckSize);
        }

        // Заранее проигрышная колода
        [Test]
        public void MarkAndElonLoseTest()
        {
            CollisiumSandbox game = new CollisiumSandbox(new Elon(new PickFirstRedCardStrategy()),
                new Mark(new PickFirstRedCardStrategy()));

            bool win = game.Play(loseDeck);
            Assert.False(win);
        }

        // Заранее выйгрышная колода
        [Test]
        public void MarkAndElonWinTest()
        {
            CollisiumSandbox game = new CollisiumSandbox(new Elon(new PickFirstRedCardStrategy()),
                new Mark(new PickFirstRedCardStrategy()));

            bool win = game.Play(winDeck);
            Assert.True(win);
        }

        // Заранее выйгрышная колода
        [Test]
        public void IntergrationTest()
        {
            Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<CollisiumExperimentWorker>();

                    services.AddScoped<CollisiumSandbox>();

                    services.AddScoped<IDeckShuffler, DeckShuffler>();
                    services.AddScoped<Elon>();
                    services.AddScoped<Mark>();

                    services.AddScoped<ICardPickMarkStrategy, StratagyNumberOne>();
                    services.AddScoped<ICardPickElonStrategy, StratagyNumberOne>();
                });

            Mock<Elon> mock1 = new Mock<Elon>();
            Mock<Mark> mock2 = new Mock<Mark>();

            mock1.Verify(p => p.ChooseCard(mock2.Object.SayCard()));
        }

        // [Test]
        // public void IntergrationTest1()
        // {
        //     Mock<Elon> mock = new Mock<Elon>(); 
        //     
        //     // IPlayer elon = new Elon(new PickFirstRedCardStrategy());
        //     IPlayer mark = new Mark(new PickFirstRedCardStrategy());
        //
        //     CollisiumSandbox game = new CollisiumSandbox(mock.Object, mark);
        //     
        //     game.Play(loseDeck);
        //     
        //     mock.Verify(p => p.ChooseCard(mark.SayCard()));
        // }
        // }

        // [Test]
        // public void MyMethodTest()
        // {
        //     string action = "test1";
        //     Mock<ISomeClass> mockSomeClass = new Mock<ISomeClass>();
        //
        //     MyClass myClass = new MyClass(mockSomeClass.Object);
        //     myClass.MyMethod(action);
        //
        //     mockSomeClass.Verify(mock => mock.DoSomething(action), Times.Once());
        // }
        // }
    }
}
