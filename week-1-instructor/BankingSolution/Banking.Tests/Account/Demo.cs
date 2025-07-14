
using Banking.Domain;
using Banking.Tests.TestDoubles;

namespace Banking.Tests.Account;

public class Demo
{
    [Fact]
    public void SomeDemo()
    {
        var barbsAccount = new BankAccount(new DummyBonusCalculator());
        //BankAccount barbsAccount = new();


        BankAccount stansAccount = new BankAccount(new DummyBonusCalculator());

        Assert.Equal(barbsAccount.GetBalance(), stansAccount.GetBalance());

        stansAccount.Deposit(420.69M); // 04/20/69 

        Assert.NotEqual(barbsAccount.GetBalance(), stansAccount.GetBalance());


    }

    [Fact]
    public void SomeOtherDemo()
    {
        var myBirthday = new DateTime(1969, 4, 20);
        var barbsBirthday = new DateTime(1974, 4, 10);

        

    }

    [Fact]
    public void Implicit()
    {
        TransactionAmount t1 = 32.00M;
        var t2 = 10M;

       
        var added = t1 += t2;

        Assert.Equal<TransactionAmount>(42M, added);

        var account = new BankAccount(new DummyBonusCalculator());
      Assert.Throws<InvalidTransactionAmountException>(() => account.Deposit(-32));
    }
}
