
using lab1;

namespace lab1
{
    public interface IPlayer {
        Card ChooseCard(int n);
        void SetCards(Card[] other);
        int SayCard();
    };
}


public class MyClass
{
    ISomeClass someClass;
    public MyClass(ISomeClass someClass)
    {
        this.someClass = someClass;     
    }

    public void MyMethod(string method)
    {
        method = "test1";
        someClass.DoSomething(method);
    }   
}

public class SomeClass : ISomeClass
{
    public void DoSomething(string method)
    {
        // do something...
    }
}

public interface ISomeClass
{
    void DoSomething(string method);
}
