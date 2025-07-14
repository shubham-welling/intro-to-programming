

using Banking.Domain;
using Banking.Tests.BonusCalculation;
using Banking.Tests.TestDoubles;

namespace Banking.Tests.LoyaltyProgram;
public class GoldAccountDeposits
{

    [Fact]
    public void GoldAccountsGetABonusOnTheirDeposits()
    {
        var account = new BankAccount(new StubbedBonusCalculator());
        var openingBalance = account.GetBalance();

        account.Deposit(100M);

        Assert.Equal(openingBalance + 520.69M, account.GetBalance());

    }
}
