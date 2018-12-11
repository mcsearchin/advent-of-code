using System.Text.RegularExpressions;
using AdventOfCode;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCodeTests
{
    public class Day9MarbleGameTests
    {
        private readonly Day9MarbleGame _subject;
        private readonly ITestOutputHelper _output;

        public Day9MarbleGameTests(ITestOutputHelper output)
        {
            _output = output;
            _subject = new Day9MarbleGame();
        }

        [Fact]
        public void GetWinningScore_ReturnsZeroWhenNumberOfMarblesIsLowerThanMagicMultipleValue()
        {
            Assert.Equal(0, _subject.GetWinningScore("1 players; last marble is worth 22 points"));
        }

        [Fact]
        public void GetWinningScore_ReturnsExpectedScoreForExample()
        {
            Assert.Equal(32, _subject.GetWinningScore("1 players; last marble is worth 25 points"));
        }

        [Fact]
        public void GetWinningScore_ReturnsExpectedScoreForSinglePlayerAndTwiceMagicMultipleValue()
        {
            Assert.Equal(95, _subject.GetWinningScore("1 players; last marble is worth 46 points"));
        }

        [Fact]
        public void GetWinningScore_ReturnsExpectedScoreForMultiplePlayersAndTwiceMagicMultipleValue()
        {
            Assert.Equal(63, _subject.GetWinningScore("2 players; last marble is worth 46 points"));
        }

        [Fact]
        public void GetWinningScore_ReturnsExpectedScoresForOtherExamples()
        {
            Assert.Equal(8317, _subject.GetWinningScore("10 players; last marble is worth 1618 points"));
            Assert.Equal(146373, _subject.GetWinningScore("13 players; last marble is worth 7999 points"));
            Assert.Equal(2764, _subject.GetWinningScore("17 players; last marble is worth 1104 points"));
            Assert.Equal(54718, _subject.GetWinningScore("21 players; last marble is worth 6111 points"));
            Assert.Equal(37305, _subject.GetWinningScore("30 players; last marble is worth 5807 points"));
        }

        [Fact]
        public async void GetWinningScore_CanFindSolutionForAdventOfCode()
        {
            var input = await new AdventOfCodeClient().Get("day/9/input");
            var score = _subject.GetWinningScore(input);
            _output.WriteLine("score : {0}", score);
        }

        [Fact]
        public async void GetWinningScore_CanFindSolutionForAdventOfCode_100TimesLarger()
        {
            var input = await new AdventOfCodeClient().Get("day/9/input");
            var original = Regex.Match(input, "[0-9]+(?= points)").Value;
            input = input.Replace(original, (int.Parse(original) * 100).ToString());
            _output.WriteLine("new input : {0}", input);
            var score = _subject.GetWinningScore(input);
            _output.WriteLine("score : {0}", score);
        }
    }
}
