using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References.Tests;

public class AddingNumbers
{
    [Fact]
    public void CanAddTheIntegersTwentyAndTenToGiveYouThirty()
    {
        int a = 10;
        int b = 20;
        int answer;

        answer = a + b;
        Assert.Equal(30, answer);
    }

    [Theory]
    [InlineData(10, 20, 30)]
    [InlineData(2, 2, 4)]
    [InlineData(10, 3, 13)]
    public void CanAddAnyTwoIntegers(int a, int b, int expected)
    {
        int answer = a + b;
        Assert.Equal(expected, answer);
    }
}
