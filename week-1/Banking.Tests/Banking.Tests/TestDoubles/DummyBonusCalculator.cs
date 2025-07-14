

using Banking.Domain;

namespace Banking.Tests.TestDoubles;
public class DummyBonusCalculator : ICalculateBonusesForBankAccounts
{
    public decimal CalculateBonusForDeposit(decimal currentBalance, TransactionAmount amountToDeposit)
    {
        return 0;
    }
}
