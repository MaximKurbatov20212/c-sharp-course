
namespace lab1
{
    public interface IPlayer {
        Card ChooseCard(int n);
        void SetCards(Card[] other);
        int SayCard();
    };
}