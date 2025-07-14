
using Banking.Domain;
using Banking.Tests.TestDoubles;

namespace Banking.Tests.Account;

public class MakingWithdrawals
{

    [Fact]
    public void MakingAWithdrawalDecreasesBalance()
    {
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();
        var amountToWithdraw = 20.23M;

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }
}
