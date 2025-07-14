
namespace StringCalculator;
public class CalculatorInteractionTests
{

    [Theory]
    [InlineData("1,2,3")]
    public void DoesLogging(string numbers)
    {
        // Given
        var mockedLogger = Substitute.For<ILogger>();
        var mockedWebService = Substitute.For<IWebService>();
        var calculator = new Calculator(mockedLogger, mockedWebService );

        // When
        var response = calculator.Add(numbers);

        // Then
        // did the logger get called with the response as a string.

        mockedLogger
            .Received()
     
            .Write(response.ToString());

        mockedWebService.DidNotReceive().NotifyOfLoggingFailure(Arg.Any<string>());
    }

    [Theory]
    [InlineData("1,2,3")]
    public void CallsWebServiceWhenLoggerThrowsAnException(string numbers)
    {
        // Given
        var stubbedLogger = Substitute.For<ILogger>();
        var mockedWebService = Substitute.For<IWebService>();
        stubbedLogger
            .When(logger => logger.Write(Arg.Any<string>()))
            .Throw(new Exception());

        var calculator = new Calculator(stubbedLogger, mockedWebService);

        // When
        var response = calculator.Add(numbers);

        // Then
        // did the logger get called with the response as a string.

        mockedWebService.Received().NotifyOfLoggingFailure(response.ToString());
    }
}
