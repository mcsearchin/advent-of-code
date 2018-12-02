using AdventOfCode;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCodeTests
{
    public class Day2BoxIdChecksumCalculatorTests
    {
        private readonly Day2BoxIdChecksumCalculator _subject;
        private readonly ITestOutputHelper _output;

        public Day2BoxIdChecksumCalculatorTests(ITestOutputHelper output)
        {
            _output = output;
            _subject = new Day2BoxIdChecksumCalculator();
        }

        [Fact]
        public void CalculateChecksum_ReturnsZeroChecksumWhenIdStringIsEmpty()
        {
            Assert.Equal(0, _subject.CalculateChecksum(""));
        }

        [Fact]
        public void CalculateChecksum_ReturnsOneForASingleIdThatContainsExactlyTwoAndThreeOfTheSameCharacter()
        {
            Assert.Equal(1, _subject.CalculateChecksum("ababa"));
        }

        [Fact]
        public void CalculateChecksum_ReturnsZeroForASingleIdThatContainsExactlyTwoButNotThreeOfTheSameCharacter()
        {
            Assert.Equal(0, _subject.CalculateChecksum("bab"));
        }

        [Fact]
        public void CalculateChecksum_ReturnsZeroForASingleIdThatContainsExactlyThreeButNotTwoOfTheSameCharacter()
        {
            Assert.Equal(0, _subject.CalculateChecksum("abaa"));
        }

        [Fact]
        public void CalculateChecksum_ReturnsFourWhenBothIdsContainsTwoAndThree()
        {
            Assert.Equal(4, _subject.CalculateChecksum("bbaaa\naaabb"));
        }

        [Fact]
        public void CalculateChecksum_ReturnsZeroWhenAllIdsContainThreeButNoneContainTwos()
        {
            Assert.Equal(0, _subject.CalculateChecksum("aaa\nbbb\nccc"));
        }

        [Fact]
        public async void CalculateChecksum_CanFindSolutionForAdventOfCode()
        {
            var client = new AdventOfCodeClient("53616c7465645f5f5bd14e6affcbcc327445c4b44178804f6d28049f607d3c1acb5d9bb0b288f156a5599cb03937889a");
            var input = await client.Get("day/2/input");
            var checksum = _subject.CalculateChecksum(input);
            _output.WriteLine("checksum : {0}", checksum);
        }
    }
}
