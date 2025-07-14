namespace Banking.Domain;

public interface ICalculateBonusesForBankAccounts
{
    decimal CalculateBonusForDeposit(decimal currentBalance, TransactionAmount amountToDeposit);
}