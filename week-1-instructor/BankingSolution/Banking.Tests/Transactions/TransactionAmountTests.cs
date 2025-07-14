
using Banking.Domain;

namespace Banking.Tests.Transactions;
public class TransactionAmountTests
{

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
 

    public void InvalidValues(decimal val)
    {
        Assert.Throws<InvalidTransactionAmountException>(
            () => new TransactionAmount(val));


    }

    [Theory]
    [InlineData(.01)]
    [InlineData(1000)]


    public void ValidValues(decimal val)
    {
        var r = new TransactionAmount(val);

        Assert.Equal<TransactionAmount>(val, r);
    }
}