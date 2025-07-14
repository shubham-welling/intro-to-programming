


namespace Banking.Domain;

public class BankAccount(ICalculateBonusesForBankAccounts _bonusCalculator)
{


    private decimal _currentBalance = 7000;
    public void Deposit(TransactionAmount amountToDeposit)
    {
        decimal bonusToApply = _bonusCalculator.CalculateBonusForDeposit(_currentBalance, amountToDeposit);
        _currentBalance += amountToDeposit + bonusToApply;
       
    }

    public decimal GetBalance() 
    {
        
        return _currentBalance;
    }

    public void Withdraw(TransactionAmount amountToWithdraw)
    {
       _currentBalance -= amountToWithdraw;
    }

  
}