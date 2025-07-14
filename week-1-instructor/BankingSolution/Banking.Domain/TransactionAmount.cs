

namespace Banking.Domain;
public readonly struct TransactionAmount
{
    private readonly decimal _amount;

    public TransactionAmount(decimal amount)
    {
        if (amount <= 0)
        {
            throw new InvalidTransactionAmountException();
        }
      
        _amount = amount;
    }

    public static implicit operator decimal(TransactionAmount tx)
    {
        return tx._amount;
    }

    public static implicit operator TransactionAmount(decimal val)
    {
        return new TransactionAmount(val);
    }
}

public class InvalidTransactionAmountException : ArgumentOutOfRangeException;