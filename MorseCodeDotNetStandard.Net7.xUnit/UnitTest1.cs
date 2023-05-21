namespace MorseCodeDotNetStandard.Net7.xUnit;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        string message = "Hello, World!";
        string result = MorseCodeDotNet.Lib.MorseCodeDecoder.Encode(message);

        Assert.True(!string.IsNullOrWhiteSpace(result), message);
    }
}
