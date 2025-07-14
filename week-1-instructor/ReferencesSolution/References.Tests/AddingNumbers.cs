
namespace References.Tests;

public class AddingNumbers
{

    [Fact]
    public void CanAddTheIntegersTwentyAndTenToGiveYouThirty()
    {
        // Given
        int a = 10;
        int b = 20;
        int answer;

        // When
        answer = a + b;

        // Then
        // Answer should be 30
        Assert.Equal(30, answer);
    }

    [Theory]
    [InlineData(10,20, 30)]
    [InlineData(2,2,4)]
    [InlineData(10,3,13)]
    public void CanAddAnyTwoIntegers(int a, int b, int expected)
    {
        int answer = a + b;
        Assert.Equal(expected, answer);
    }

    [Fact]
    public void ObjectEquality()
    {
        var dog1 = new Dog { Name = "Fido", Breed = "Cairn Terrier" };
       var dog2 = new Dog { Name = "Fido", Breed = "Cairn Terrier" };
        //var dog2 = dog1;

        Assert.Equal(dog1, dog2);

        //Assert.Equal("blah", dog1.ToString());
    }
}


public record Dog 
{
    public string Name { get; set; } = string.Empty;
    public string Breed { get; set; } = string.Empty;

  
}