using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MorseCodeDotNet.Library;

public static class MorseCode
{
	private const string MORSE_WORD_SEPARATOR = "  ";
	private const char MORSE_LETTER_SEPARATOR = ' ';
	private const char TEXT_WORD_SEPARATOR = ' ';

	private static readonly Dictionary<char, string> morseDictionary = new()
	{
		{ 'A', ".-" }, { 'B', "-..." }, { 'C', "-.-." }, { 'D', "-.." },
		{ 'E', "." }, { 'F', "..-." }, { 'G', "--." }, { 'H', "...." },
		{ 'I', ".." }, { 'J', ".---" }, { 'K', "-.-" }, { 'L', ".-.." },
		{ 'M', "--" }, { 'N', "-." }, { 'O', "---" }, { 'P', ".--." },
		{ 'Q', "--.-" }, { 'R', ".-." }, { 'S', "..." }, { 'T', "-" },
		{ 'U', "..-" }, { 'V', "...-" }, { 'W', ".--" }, { 'X', "-..-" },
		{ 'Y', "-.--" }, { 'Z', "--.." }, { '0', "-----" }, { '1', ".----" },
		{ '2', "..---" }, { '3', "...--" }, { '4', "....-" }, { '5', "....." },
		{ '6', "-...." }, { '7', "--..." }, { '8', "---.." }, { '9', "----." }
	};

	// Dictionnaire inversé pour le décodage
	private static readonly Dictionary<string, char> reverseMorseDictionary = morseDictionary
		.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

	public static string Decode(string morseCode)
	{
		if (string.IsNullOrWhiteSpace(morseCode))
			return string.Empty;

		var trimmedMorseCode = morseCode.Trim();
		var words = trimmedMorseCode.Split(MORSE_WORD_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);

		var sbOutput = new StringBuilder();

		foreach (var word in words)
		{
			var letters = word.Split(MORSE_LETTER_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);

			foreach (var letter in letters)
			{
				if (reverseMorseDictionary.TryGetValue(letter, out var decodedChar))
				{
					sbOutput.Append(decodedChar);
				}
			}

			sbOutput.Append(TEXT_WORD_SEPARATOR);
		}

		return sbOutput.ToString().TrimEnd();
	}

	public static string Encode(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
			return string.Empty;

		var trimmedValue = value.ToUpper(CultureInfo.InvariantCulture).Trim();
		var words = trimmedValue.Split(TEXT_WORD_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);

		var sbOutput = new StringBuilder();

		foreach (var word in words)
		{
			foreach (var letter in word)
			{
				if (morseDictionary.TryGetValue(letter, out var morseCodeValue))
				{
					sbOutput.Append(morseCodeValue);
					sbOutput.Append(MORSE_LETTER_SEPARATOR);
				}
			}

			sbOutput.Append(MORSE_WORD_SEPARATOR);
		}

		return sbOutput.ToString().TrimEnd();
	}
}
