
using System.Reflection.Metadata.Ecma335;

public class Calculator
{
    public int Add(string numbers)
    {
        Console.WriteLine(numbers);
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }
        else if (numbers.All(Char.IsDigit))
        {
            return int.Parse(numbers);
        }
        else
        {
            string temp = numbers.Replace(",", "").Replace("\n", "");
            
            string customDelimiter = null;
            if (numbers.Substring(0,2) == "//")
            {
                customDelimiter = temp.Substring(2, 1);
                Console.WriteLine("DELIMITER IS " + customDelimiter);
                temp = temp.Replace(customDelimiter, "").Replace("//", "");
            }

            int runningSum = 0;
            foreach (char c in temp)
            {
                runningSum += int.Parse(c.ToString());
            }
            return runningSum;
        }
        return -42;
    }
}
