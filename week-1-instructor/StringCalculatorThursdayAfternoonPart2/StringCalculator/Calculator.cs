


public class Calculator(ILogger _logger, IWebService _webService)
{
    public int Add(string numbers)
    {
        List<char> delimeters = [',', '\n'];

        if (numbers == "")
        {
            return 0;
        }

        if (HasCustomDelimeters(numbers))
        {

            var delimeter = numbers[2];
            delimeters.Add(delimeter);
            numbers = numbers[4..];

        }

        var response =  numbers.Split([.. delimeters]) //string[]
             .Select(int.Parse) // int[]
             .Sum();

        // right here, log this sucker out.

        try
        {
            _logger.Write(response.ToString());
        }
        catch (Exception)
        {

           _webService.NotifyOfLoggingFailure(response.ToString());
        }
        return response;

    }

    private bool HasCustomDelimeters(string numbers)
    {
        return numbers.StartsWith("//");
    }
}
