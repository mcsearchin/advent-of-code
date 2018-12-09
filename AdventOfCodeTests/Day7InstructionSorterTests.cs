using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode
{
    public class Day7AssemblyInstructionsTests
    {
        private readonly Day7AssemblyInstructions _subject;
        private readonly ITestOutputHelper _output;

        public Day7AssemblyInstructionsTests(ITestOutputHelper output)
        {
            _output = output;
            _subject = new Day7AssemblyInstructions();
        }

        [Fact]
        public void SortInstructionSteps_ReturnsTwoStepsInOrderFromASingleInstruction()
        {
            var instructions = new[] {"Step A must be finished before step B can begin."};

            Assert.Equal("AB", _subject.SortInstructionSteps(instructions));
        }

        [Fact]
        public void SortInstructionSteps_ReturnsStepsInAlphabeticalOrderFromMultipleStepsWithNoDependencies()
        {
            var instructions = new[]
            {
                "Step A must be finished before step C can begin.",
                "Step B must be finished before step D can begin."
            };

            Assert.Equal("ABCD", _subject.SortInstructionSteps(instructions));
        }

        [Fact]
        public void SortInstructionSteps_ReturnsStepsInDependentOrderFromMultipleSteps()
        {
            var instructions = new[]
            {
                "Step A must be finished before step C can begin.",
                "Step C must be finished before step B can begin."
            };

            Assert.Equal("ACB", _subject.SortInstructionSteps(instructions));
        }

        [Fact]
        public void SortInstructionSteps_ReturnsStepsInDependentAndAlphabeticalOrderFromMultipleSteps()
        {
            var instructions = new[]
            {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin."
            };

            Assert.Equal("CABDFE", _subject.SortInstructionSteps(instructions));
        }

        [Fact]
        public void SortInstructionSteps_ReturnsStepsInDependentAndAlphabeticalWhenMultipleStepsAreNotChildrenOfDependencies()
        {
            var instructions = new[]
            {
                "Step X must be finished before step A can begin.",
                "Step Y must be finished before step A can begin.",
                "Step A must be finished before step C can begin.",
                "Step A must be finished before step B can begin.",
            };

            Assert.Equal("XYABC", _subject.SortInstructionSteps(instructions));
        }

        [Fact]
        public async void SortInstructionSteps_CanFindSolutionForAdventOfCode()
        {
            var input = await new AdventOfCodeClient().GetLines("day/7/input");
            var sortedSteps = _subject.SortInstructionSteps(input);
            _output.WriteLine("sortedSteps : {0}", sortedSteps);
        }

        [Fact]
        public void CalculateTimeToComplete_ReturnsSumOfStepDurationsForASingleStep()
        {
            var instructions = new[] {"Step A must be finished before step B can begin."};

            Assert.Equal(3, _subject.CalculateTimeToComplete(instructions));
        }

        [Fact]
        public void CalculateTimeToComplete_ReturnsMaxPathDurationForMultipleStepsWithNoDependencies()
        {
            var instructions = new[]
            {
                "Step A must be finished before step C can begin.",
                "Step B must be finished before step D can begin."
            };

            Assert.Equal(6, _subject.CalculateTimeToComplete(instructions));
        }

        [Fact]
        public void CalculateTimeToComplete_ReturnsCorrectDurationForMultipleStepsWithLimitedWorkers()
        {
            var instructions = new[]
            {
                "Step A must be finished before step F can begin.",
                "Step B must be finished before step E can begin.",
                "Step C must be finished before step D can begin."
            };

            Assert.Equal(13, _subject.CalculateTimeToComplete(instructions, 2));
        }

        [Fact]
        public void CalculateTimeToComplete_ReturnsProperDurationForMultipleStepsWithDependencies()
        {
            var instructions = new[]
            {
                "Step A must be finished before step C can begin.",
                "Step C must be finished before step B can begin."
            };

            Assert.Equal(6, _subject.CalculateTimeToComplete(instructions));
        }

        [Fact]
        public void CalculateTimeToComplete_ReturnsProperDurationForExampleSteps()
        {
            var instructions = new[]
            {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin."
            };

            Assert.Equal(15, _subject.CalculateTimeToComplete(instructions, 2));
        }

        [Fact]
        public async void CalculateTimeToComplete_CanFindSolutionForAdventOfCode()
        {
            var input = await new AdventOfCodeClient().GetLines("day/7/input");
            var time = _subject.CalculateTimeToComplete(input);
            _output.WriteLine("time : {0}", time);
        }
    }
}
