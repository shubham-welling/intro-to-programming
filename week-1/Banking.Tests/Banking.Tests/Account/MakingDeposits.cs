

using Banking.Domain;
using Banking.Tests.TestDoubles;

namespace Banking.Tests.Account;

public class MakingDeposits
{
    [Theory]
    [InlineData(100)]
    [InlineData(223.89)]

    public void MakingADepositIncreasesTheBalance(decimal amountToDeposit)
    {
        // Given
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();


        // When
        account.Deposit(amountToDeposit);

        // Then
        Assert.Equal(amountToDeposit + openingBalance, account.GetBalance());
    }
}
