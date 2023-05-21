using System.Collections.Generic;
using System.Text;

namespace MorseCodeDotNetStandard.Lib;

public class MorseCodeDecoder
{
    private const string MORSE_WORD_SEPARATOR = "   ";
    private const string MORSE_LETTER_SEPARATOR = " ";
    private const string TEXT_WORD_SEPARATOR = " ";

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
        StringBuilder sbOutput = new();

        string trimmedMorseCode = morseCode.ToUpper().Trim();
        string[] words = trimmedMorseCode.Split(MORSE_WORD_SEPARATOR.ToCharArray());

        foreach (var w in words)
        {
            string[] letters = w.Split(MORSE_LETTER_SEPARATOR);

            foreach (var l in letters)
            {
                sbOutput.Append(morseDictionary.KeyByValue(l));
            }

            sbOutput.Append(TEXT_WORD_SEPARATOR);
        }

        return sbOutput.ToString();
    }

    public static string Encode(string value)
    {
        StringBuilder sbOutput = new();

        string trimmedValue = value.ToUpper().Trim();
        string[] words = trimmedValue.Split(TEXT_WORD_SEPARATOR.ToCharArray());

        foreach (var word in words)
        {
            char[] letters = word.ToCharArray();

            foreach (var l in letters)
            {
                morseDictionary.TryGetValue(l, out value);
                sbOutput.Append(value ?? " ");
                sbOutput.Append(MORSE_LETTER_SEPARATOR);
            }

            sbOutput.Append(MORSE_WORD_SEPARATOR);
        }

        return sbOutput.ToString();
    }
}

