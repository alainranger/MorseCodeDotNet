using MorseCodeDotNet.Library;

namespace MorseCodeDotNetStandard.Net7.xUnit;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "<Pending>")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
public class MorseCodeTests
{
	public static readonly IEnumerable<object[]> morseCodeTestData =
	[
		[".-", "A"],
		["-...", "B"],
		["-.-.", "C"],
		["-..", "D"],
		[".", "E"],
		["..-.", "F"],
		["--.", "G"],
		["....", "H"],
		["..", "I"],
		[".---", "J"],
		["-.-", "K"],
		[".-..", "L"],
		["--", "M"],
		["-.", "N"],
		["---", "O"],
		[".--.", "P"],
		["--.-", "Q"],
		[".-.", "R"],
		["...", "S"],
		["-", "T"],
		["..-", "U"],
		["...-", "V"],
		[".--", "W"],
		["-..-", "X"],
		["-.--", "Y"],
		["--..", "Z"],
		["-----", "0"],
		[".----", "1"],
		["..---", "2"],
		["...--", "3"],
		["....-", "4"],
		[".....", "5"],
		["-....", "6"],
		["--...", "7"],
		["---..", "8"],
		["----.", "9"]
	];

	public static readonly IEnumerable<object[]> reverseMorseCodeTestData =
		morseCodeTestData.Select(x =>
		{
			var morseCode = x[0].ToString()!;
			var letter = x[1].ToString()!;
			return new object[] { letter, morseCode };
		});

	[Theory]
	[MemberData(nameof(morseCodeTestData))]
	public void Decode_Should_ReturnExpextedValue_WhenValueIsLetter(string morseCode, string expected)
	{
		// Act
		var result = MorseCode.Decode(morseCode);

		// Assert
		Assert.Equal(expected, result);
	}

	[Fact]
	public void Decode_Should_ReturnExpextedValue_IsWord()
	{
		// Act
		var result = MorseCode.Decode(".- .-.. .-.. .. .");

		// Assert
		Assert.Equal("ALLIE", result);
	}

	[Fact]
	public void Decode_Should_ReturnExpextedValue_IsSentence()
	{
		// Act
		var result = MorseCode.Decode(".- .-.. .-.. .. .   -- --- .-. ... .   -.-. --- -.. .");

		// Assert
		Assert.Equal("ALLIE MORSE CODE", result);
	}

	[Theory]
	[MemberData(nameof(reverseMorseCodeTestData))]
	public void Encode_Should_ReturnExpextedValue_WhenValueIsLetter(string letter, string expected)
	{
		// Act
		var result = MorseCode.Encode(letter);

		// Assert
		Assert.Equal(expected, result);
	}

	[Fact]
	public void Encode_Should_ReturnExpextedValue_IsWord()
	{
		// Act
		var result = MorseCode.Encode("ALLIE");

		// Assert
		Assert.Equal(".- .-.. .-.. .. .", result);
	}

	[Fact]
	public void Encode_Should_ReturnExpextedValue_IsSentence()
	{
		// Act
		var result = MorseCode.Encode("ALLIE MORSE CODE");

		// Assert
		Assert.Equal(".- .-.. .-.. .. .   -- --- .-. ... .   -.-. --- -.. .", result);
	}
}
