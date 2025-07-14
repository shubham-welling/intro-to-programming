namespace References.Api;

public class NameFormatter
{
    public string FormatName(string firstName,  string lastName, char mi)
    {
        return $"{firstName} {lastName}";
    }
}
