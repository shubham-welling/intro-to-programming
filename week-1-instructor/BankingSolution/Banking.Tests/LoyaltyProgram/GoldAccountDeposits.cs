

using Banking.Domain;
using Banking.Tests.BonusCalculation;
using Banking.Tests.TestDoubles;
using NSubstitute;

namespace Banking.Tests.LoyaltyProgram;
public class GoldAccountDeposits
{

    [Fact]
    public void GoldAccountsGetABonusOnTheirDeposits()
    {
        // Given
        var stubbedBonusCalculator = Substitute.For<ICalculateBonusesForBankAccounts>();
       

        var account = new BankAccount(stubbedBonusCalculator);
        var openingBalance = account.GetBalance();
        stubbedBonusCalculator.CalculateBonusForDeposit(openingBalance, 100M).Returns(420.69M);

        // When
        account.Deposit(100M);


        // Then
        Assert.Equal(openingBalance + 520.69M, account.GetBalance());
        
    }
}
