using AdventOfCode;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCodeTests
{
    public class Day5PolymerScannerTests
    {
        private readonly Day5PolymerScanner _subject;
        private readonly ITestOutputHelper _output;

        public Day5PolymerScannerTests(ITestOutputHelper output)
        {
            _output = output;
            _subject = new Day5PolymerScanner();
        }

        [Fact]
        public void CountUnits_ReturnsZeroCountWhenPolymerStringIsEmpty()
        {
            Assert.Equal(0, _subject.CountUnits(""));
        }

        [Fact]
        public void CountUnits_ReturnsLengthOfStringWhenPolymerStringHasNoReactingUnits()
        {
            Assert.Equal(6, _subject.CountUnits("aaBcDD"));
        }

        [Fact]
        public void CountUnits_ReducesCountWhenTwoUnitsCancelEachOtherOut()
        {
            Assert.Equal(4, _subject.CountUnits("aBbcDD"));
        }

        [Fact]
        public void CountUnits_ReducesCountWhenTwoUnitsCancelEachOtherOutWithReversedPolarities()
        {
            Assert.Equal(4, _subject.CountUnits("abBcDD"));
        }

        [Fact]
        public void CountUnits_ReducesCountWhenMultiplePairsOfUnitsCancelEachOtherOut()
        {
            Assert.Equal(3, _subject.CountUnits("abBCccDdCee"));
        }

        [Fact]
        public async void CountUnits_CanFindSolutionForAdventOfCode()
        {
            var input = await new AdventOfCodeClient().Get("day/5/input");
            var unitCount = _subject.CountUnits(input);
            _output.WriteLine("unitCount : {0}", unitCount);
        }
    }
}
