using AdventOfCode;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCodeTests
{
    public class Day1FrequencyCalculatorTests
    {
        private readonly Day1FrequencyCalculator _subject;
        private readonly ITestOutputHelper _output;

        public Day1FrequencyCalculatorTests(ITestOutputHelper output)
        {
            _subject = new Day1FrequencyCalculator();
            _output = output;
        }

        [Fact]
        public void CalculateChange_SingleFrequencyChangeResultsInSameNumber()
        {
            Assert.Equal(41, _subject.CalculateChange("+41"));
        }

        [Fact]
        public void CalculateChange_MultipleFrequencyChangesResultInSumOfNumbers()
        {
            Assert.Equal(48, _subject.CalculateChange("+41\n+7"));
        }

        [Fact]
        public void CalculateChange_MultipleFrequencyChangesCanBePositiveOrNegativeStillResultInSumOfNumbers()
        {
            Assert.Equal(34, _subject.CalculateChange("+41\n-7"));
        }

        [Fact]
        public void CalculateChange_NonNumericValuesAreIgnored()
        {
            Assert.Equal(2, _subject.CalculateChange("+1\n\n+1"));
        }

        [Fact]
        public async void CalculateChange_CanCalculateFrequencyChangeForAdventOfCode()
        {
            var client = new AdventOfCodeClient("53616c7465645f5f5bd14e6affcbcc327445c4b44178804f6d28049f607d3c1acb5d9bb0b288f156a5599cb03937889a");
            var input = await client.Get("day/1/input");
            var frequencyChange = _subject.CalculateChange(input);
            _output.WriteLine("frequencyChange : {0}", frequencyChange);
        }

        [Fact]
        public void FindFirstDuplicateFrequency_TheSamePositiveAndNegativeValueResultsInZero()
        {
            Assert.Equal(0, _subject.FindFirstDuplicateFrequency("+41\n-41"));
        }

        [Fact]
        public void FindFirstDuplicateFrequency_CanBeFoundInTheMiddleOfTheSequence()
        {
            Assert.Equal(41, _subject.FindFirstDuplicateFrequency("+41\n-3\n+3\n"));
        }

        [Fact]
        public async void FindFirstDuplicateFrequency_CanFindSolutionForAdventOfCode()
        {
            var client = new AdventOfCodeClient("53616c7465645f5f5bd14e6affcbcc327445c4b44178804f6d28049f607d3c1acb5d9bb0b288f156a5599cb03937889a");
            var input = await client.Get("day/1/input");
            var duplicateFrequency = _subject.FindFirstDuplicateFrequency(input);
            _output.WriteLine("duplicateFrequency : {0}", duplicateFrequency);
        }
    }
}
