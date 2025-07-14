
using Banking.Domain;
using Banking.Tests.TestDoubles;

namespace Banking.Tests.Account;

public class NewAccount
{
    // Newly Opened Bank Accounts have a starting balance of $5000.00

    [Fact]
    public void NewAccountsHaveCorrectOpeningBalance()
    {
        var account = new BankAccount(new DummyBonusCalculator());
        var expectedOpeningBalance = 7000.00M;

        decimal actualBalance = account.GetBalance();

        Assert.Equal(expectedOpeningBalance, actualBalance);

    }
}
