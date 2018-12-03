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
            var input = await new AdventOfCodeClient().Get("day/2/input");
            var checksum = _subject.CalculateChecksum(input);
            _output.WriteLine("checksum : {0}", checksum);
        }

        [Fact]
        public void FindCommonBoxIdString_ReturnsNullWhenMultipleConsecutiveCharactersVary()
        {
            Assert.Null(_subject.FindCommonBoxIdString("abcd\naxyd"));
        }

        [Fact]
        public void FindCommonBoxIdString_ReturnsExpectedCommonStringWhenOnlySingleCharacterDoesNotMatch()
        {
            Assert.Equal("acd", _subject.FindCommonBoxIdString("abcd\naxcd"));
        }

        [Fact]
        public void FindCommonBoxIdStringr_ReturnsNullWhenMultipleNonConsecutiveCharactersVary()
        {
            Assert.Null(_subject.FindCommonBoxIdString("abcd\naxcy"));
        }

        [Fact]
        public void FindCommonBoxIdString_ReturnsExpectedCommonStringWhenSingleCharacterDoesNotMatchForNonConsecutivIds()
        {
            Assert.Equal("abd", _subject.FindCommonBoxIdString("axyd\nabcd\nacbd\nabxd"));
        }

        [Fact]
        public async void FindCommonBoxIdString_CanFindSolutionForAdventOfCode()
        {
            var input = await new AdventOfCodeClient().Get("day/2/input");
            var commonBoxIdString = _subject.FindCommonBoxIdString(input);
            _output.WriteLine("commonBoxIdString : {0}", commonBoxIdString);
        }
    }
}
