namespace Banking.Domain;

public class StandardBonusCalculator : ICalculateBonusesForBankAccounts
{
    public decimal CalculateBonusForDeposit(decimal currentBalance, TransactionAmount amountToDeposit)
    {
        return currentBalance >= 5000M ? amountToDeposit * .20M : 0;
    }
}