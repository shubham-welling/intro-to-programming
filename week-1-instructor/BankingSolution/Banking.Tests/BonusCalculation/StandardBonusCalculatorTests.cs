

using Banking.Domain;

namespace Banking.Tests.BonusCalculation;
public  class StandardBonusCalculatorTests
{

    [Theory]
    [InlineData(5000, 100, 20)]
    [InlineData(4999.99, 100, 0)]
    public void GivesRightBonusForBankAccountDeposits(decimal balance, decimal deposit, decimal expected)
    {
        ICalculateBonusesForBankAccounts account = new StandardBonusCalculator();

        var bonus = account.CalculateBonusForDeposit(balance, deposit);

        Assert.Equal(expected, bonus);
    }
}
