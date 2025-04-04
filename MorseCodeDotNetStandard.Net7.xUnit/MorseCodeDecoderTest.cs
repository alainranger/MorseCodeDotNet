namespace MorseCodeDotNetStandard.Net7.xUnit;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "<Pending>")]
public class MorseCodeDecoderTest
{
	[Fact]
	public void Test1()
	{
		var message = "Hello, World!";
		var result = MorseCodeDotNet.Library.MorseCodeDecoder.Encode(message);

		Assert.True(!string.IsNullOrWhiteSpace(result), message);
	}
}
