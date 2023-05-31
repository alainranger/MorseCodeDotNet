using Xunit;
using MorseCodeDotNet.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Bson;

namespace MorseCodeDotNet.Lib.Tests
{
    public class MorseCodeDecoderTests
    {
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
            { '9', "----." }
        };

        public static IEnumerable<object[]> DataTest =>
            new List<object[]>()
            { 
                new object[] {"HELLO WORLD", ".... . .-.. .-.. ---   .-- --- .-. .-.. -.."},
            };

        [Fact()]
        public void DecodeTest()
        {
            foreach (var i in morseDictionary)
            {
                string valueToEncode = i.Value.ToString();
                string expectedResult = i.Key.ToString();

                string result = MorseCodeDecoder.Decode(valueToEncode);
                Assert.True(expectedResult.Equals(result));
            }
        }

        [Fact()]
        public void EncodeTest()
        {
            foreach(var i in morseDictionary)
            {
                string valueToEncode = i.Key.ToString();
                string expectedResult = i.Value.ToString();

                string result = MorseCodeDecoder.Encode(valueToEncode);
                Assert.True(expectedResult.Equals(result));
            }
        }

        [Theory]
        [MemberData(nameof(DataTest))]
        public void DecodePhrase(string message, string morseCode)
        {
            string result = MorseCodeDecoder.Decode(morseCode);

            Assert.True(message.Equals(result));

        }

        [Theory]
        [MemberData(nameof(DataTest))]
        public void EncodePhrase(string Message, string MorseCode)
        {
            string result = MorseCodeDecoder.Encode(Message);

            Assert.True(MorseCode.Equals(result));
        }
    }
}