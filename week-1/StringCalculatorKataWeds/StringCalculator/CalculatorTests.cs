

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringCalculator;
public class CalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new Calculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("2")]
    [InlineData("3")]
    [InlineData("0")]
    public void StringWithSingleIntegerIsConvertedToIntegerAndReturned(string number)
    {
        var calculator = new Calculator();
        var convertedNumber = int.Parse(number);
        var result = calculator.Add(number);

        Assert.True(result.GetType() == typeof(int));
        Assert.Equal(convertedNumber, result);
    }


    [Theory]
    [InlineData("2", "3", 5)]
    [InlineData("5", "4", 9)]
    public void StringContainingTwoNumbersSeparatedByACommaReturnsTheSum(string firstNumber, string secondNumber, int expectedSum)
    {
        string input = firstNumber + "," + secondNumber;
        var calculator = new Calculator();
        var result = calculator.Add(input);

        Assert.True(result.GetType() == typeof(int));
        Assert.Equal(expectedSum, result);
    }


    [Theory]
    [InlineData("2,3", 5)]
    [InlineData("5,4,2,3", 14)]
    public void StringContainingArbitraryLengthOfNumbersSeparatedByACommaReturnsTheSum(string input, int expectedSum)
    {
        var calculator = new Calculator();
        var result = calculator.Add(input);

        Assert.True(result.GetType() == typeof(int));
        Assert.Equal(expectedSum, result);
    }
    [Theory]
    [InlineData("2,3", 5)]
    [InlineData("5\n4,2,3", 14)]
    public void StringContainingArbitraryLengthOfNumbersSeparatedCommaOrNewlineReturnsTheSum(string input, int expectedSum)
    {
        var calculator = new Calculator();
        var result = calculator.Add(input);

        Assert.True(result.GetType() == typeof(int));
        Assert.Equal(expectedSum, result);
    }

    [Theory]
    [InlineData("//#\n2#3", 5)]
    [InlineData("//$\n5\n4,2$3", 14)]
    public void StringContainingArbitraryLengthOfNumbersSeparatedByCustomDelimiterReturnsTheSum(string input, int expectedSum)
    {
        var calculator = new Calculator();
        var result = calculator.Add(input);

        Assert.True(result.GetType() == typeof(int));
        Assert.Equal(expectedSum, result);
    }
}
