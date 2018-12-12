using AdventOfCode;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCodeTests
{
    public class Day11MaxPowerFinderTests
    {
        private readonly Day11MaxPowerFinder _subject;
        private readonly ITestOutputHelper _output;

        public Day11MaxPowerFinderTests(ITestOutputHelper output)
        {
            _output = output;
            _subject = new Day11MaxPowerFinder();
        }

        [Fact]
        public void FindMaxPowerSquareCoordinates_GivesExpectedResultForExamples()
        {
            Assert.Equal((33, 45), _subject.FindMaxPowerSquareCoordinates(18));
            Assert.Equal((21, 61), _subject.FindMaxPowerSquareCoordinates(42));
        }

        [Fact]
        public async void FindMaxPowerSquareCoordinates_CanFindSolutionForAdventOfCode()
        {
            var coordinates = _subject.FindMaxPowerSquareCoordinates(2694);
            _output.WriteLine("coordinates : {0}", coordinates);
        }
    }
}
