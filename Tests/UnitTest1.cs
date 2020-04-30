using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var diamondBuilder = new DiamondBuilder();
            var result = diamondBuilder.Build('A');

            Assert.Equal(new string[] { "A" }, result);
        }


        [Fact]
        public void Should_return_two_letters()
        {
            var diamondBuilder = new DiamondBuilder();

            Assert.StartsWith("B", diamondBuilder.Build('B')[0]);
        }

        [Fact]
        public void MidPointContainsInternalPadding()
        {
            var diamondBuilder = new DiamondBuilder();

            Assert.Equal("B B", diamondBuilder.Build('B')[1]);
        }


        [Fact]
        public void Should_return_two_letters_with_spaces()
        {
            var diamondBuilder = new DiamondBuilder();

            var result = new string[] { "B B", " A " };

            Assert.Equal(result, diamondBuilder.Build('B'));
        }

        [Fact]
        public void Should_return_three_letters_with_spaces()
        {
            var diamondBuilder = new DiamondBuilder();

            var result = new string[] { "C   C", " B B ", "  A  " };

            Assert.Equal(result, diamondBuilder.Build('C'));
        }

        [Fact]
        public void TestForD()
        {
            var diamondBuilder = new DiamondBuilder();

            var result = new string[]
            {
             "D     D",
             " C   C ",
             "  B B  ",
             "   A   "
            };

            Assert.Equal(result, diamondBuilder.Build('D'));
        }
    }

    internal class DiamondBuilder
    {
        public string[] Build(char letter)
        {
            List<string> result = new List<string>();

            for (char i = letter; i >= 'A'; i--)
            {
                int lengthOfLine = GetLength(letter);
                int outerPaddingLength = letter - i;
                string padding = new string(' ', outerPaddingLength);// (int) lengthOfLine GetOuterPaddingLength(letter, i, lengthOfLine);

                if (i != 'A')
                {
                    result.Add($"{padding}{i}{new string(' ', lengthOfLine - 2 - (2 * outerPaddingLength))}{i}{padding}");
                }
                else
                {
                    result.Add($"{padding}{i}{padding}");
                }

            }

            return result.ToArray();
        }

        private static string GetOuterPaddingLength(char letter, char i, int lengthOfLine)
        {
            int paddingLength = lengthOfLine / 2;

            string padding = i == letter ? "" : new string(' ', paddingLength);
            return padding;
        }

        private int GetLength(char letter)
        {
            int index = letter - 'A';
            return 2 * (index + 1) - 1;
        }
    }
}
