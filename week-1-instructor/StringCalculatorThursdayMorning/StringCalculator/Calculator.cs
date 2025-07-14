
public class Calculator
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

        return numbers.Split([.. delimeters]) //string[]
             .Select(int.Parse) // int[]
             .Sum();


    }

    private bool HasCustomDelimeters(string numbers)
    {
        return numbers.StartsWith("//");
    }
}
