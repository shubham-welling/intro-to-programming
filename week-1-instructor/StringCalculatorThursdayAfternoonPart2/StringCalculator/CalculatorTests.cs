
using NSubstitute;
namespace StringCalculator;

public class CalculatorTests
{
    private Calculator _calculator = new (Substitute.For<ILogger>(), Substitute.For<IWebService>());

    [Fact]
    public void EmptyStringReturnsZero()
    {
      

        var result = _calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1",1)]
    [InlineData("2",2)]
    [InlineData("420",420)]
    public void CanAddSingleInteger(string numbers, int expected)
    {
       
        var result = _calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("2,2", 4)]
    [InlineData("12,10", 22)]
    
    public void CanAddTwoNumbers(string numbers, int expected)
    {
        
        var result = _calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,3", 6)]
    

    public void ArbitraryLength(string numbers, int expected)
    {
       
        var result = _calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1\n2", 3)]
    [InlineData("1,2\n3", 6)]

    public void NewLineDelimeters(string numbers, int expected)
    {

        var result = _calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//;\n1;4",5)]
    [InlineData("//*\n1*2", 3)]

    public void CustomDelimeters(string numbers, int expected)
    {

        var result = _calculator.Add(numbers);
        Assert.Equal(expected, result);
    }



}
