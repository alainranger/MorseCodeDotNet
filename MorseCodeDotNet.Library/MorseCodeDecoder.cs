using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MorseCodeDotNet.Library;

public static class MorseCodeDecoder
{
	private const string MORSE_WORD_SEPARATOR = "   ";
	private const char MORSE_LETTER_SEPARATOR = ' ';
	private const char TEXT_WORD_SEPARATOR = ' ';

	private static readonly Dictionary<char, string> morseDictionary = new()
	{
		{ 'A', ".-" },
		{ 'B', "-..." },
		{ 'C', "-.-." },
		{ 'D', "-.." },
		{ 'E', "." },
		{ 'F', "..-." },
		{ 'G', "--." },
		{ 'H', "...." },
		{ 'I', ".." },
		{ 'J', ".---" },
		{ 'K', "-.-" },
		{ 'L', ".-.." },
		{ 'M', "--" },
		{ 'N', "-." },
		{ 'O', "---" },
		{ 'P', ".--." },
		{ 'Q', "--.-" },
		{ 'R', ".-." },
		{ 'S', "..." },
		{ 'T', "-" },
		{ 'U', "..-" },
		{ 'V', "...-" },
		{ 'W', ".--" },
		{ 'X', "-..-" },
		{ 'Y', "-.--" },
		{ 'Z', "--.." },
		{ '0', "-----" },
		{ '1', ".----" },
		{ '2', "..---" },
		{ '3', "...--" },
		{ '4', "....-" },
		{ '5', "....." },
		{ '6', "-...." },
		{ '7', "--..." },
		{ '8', "---.." },
		{ '9', "----." },

	};

	public static string Decode(string morseCode)
	{
		if (string.IsNullOrWhiteSpace(morseCode))
			return string.Empty;

		StringBuilder sbOutput = new();

		var trimmedMorseCode = morseCode.ToUpper(CultureInfo.InvariantCulture).Trim();
		var words = trimmedMorseCode.Split(MORSE_WORD_SEPARATOR.ToCharArray());

		foreach (var w in words)
		{
			var letters = w.Split(MORSE_LETTER_SEPARATOR);

			foreach (var l in letters)
			{
				sbOutput.Append(morseDictionary.FirstOrDefault(x => x.Value == l).Key);
			}

			sbOutput.Append(TEXT_WORD_SEPARATOR);
		}

		return sbOutput.ToString();
	}

	public static string Encode(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
			return string.Empty;

		StringBuilder sbOutput = new();

		var trimmedValue = value.ToUpper(CultureInfo.InvariantCulture).Trim();
		var words = trimmedValue.Split(TEXT_WORD_SEPARATOR);

		foreach (var word in words)
		{
			var letters = word.ToCharArray();

			foreach (var l in letters)
			{
				morseDictionary.TryGetValue(l, out var morseCodeValue);
				sbOutput.Append(morseCodeValue ?? " ");
				sbOutput.Append(MORSE_LETTER_SEPARATOR);
			}

			sbOutput.Append(MORSE_WORD_SEPARATOR);
		}

		return sbOutput.ToString();
	}
}
