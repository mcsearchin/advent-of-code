using AdventOfCode;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCodeTests
{
    public class Day4GuardSleepAnalyzerTests
    {
        private readonly Day4GuardSleepAnalyzer _subject;
        private readonly ITestOutputHelper _output;

        public Day4GuardSleepAnalyzerTests(ITestOutputHelper output)
        {
            _output = output;
            _subject = new Day4GuardSleepAnalyzer();
        }

        [Fact]
        public void FindSleepiestGuardAndMinute_ReturnsOnlyGuardAndOnlyMinute()
        {
            var guardLogStrings = new[]
            {
                "[1518-05-04 23:56] Guard #523 begins shift",
                "[1518-05-05 00:25] falls asleep",
                "[1518-05-05 00:26] wakes up",
            };

            var result = _subject.FindSleepiestGuardAndMinute(guardLogStrings);

            Assert.Equal(523, result.guardId);
            Assert.Equal(25, result.minute);
        }

        [Fact]
        public void FindSleepiestGuardAndMinute_ReturnsOnlyGuardAndMostSleepyMinute()
        {
            var guardLogStrings = new[]
            {
                "[1518-05-04 23:59] Guard #523 begins shift",
                "[1518-05-05 00:25] falls asleep",
                "[1518-05-05 00:27] wakes up",
                "[1518-05-05 23:59] Guard #523 begins shift",
                "[1518-05-06 00:26] falls asleep",
                "[1518-05-06 00:28] wakes up",
            };

            var result = _subject.FindSleepiestGuardAndMinute(guardLogStrings);

            Assert.Equal(523, result.guardId);
            Assert.Equal(26, result.minute);
        }

        [Fact]
        public void FindSleepiestGuardAndMinute_ReturnsOnlyGuardAndFirstMostSleepyMinute()
        {
            var guardLogStrings = new[]
            {
                "[1518-05-04 23:59] Guard #523 begins shift",
                "[1518-05-05 00:25] falls asleep",
                "[1518-05-05 00:28] wakes up",
                "[1518-05-05 23:59] Guard #523 begins shift",
                "[1518-05-06 00:26] falls asleep",
                "[1518-05-06 00:29] wakes up",
            };

            var result = _subject.FindSleepiestGuardAndMinute(guardLogStrings);

            Assert.Equal(523, result.guardId);
            Assert.Equal(26, result.minute);
        }

        [Fact]
        public void FindSleepiestGuardAndMinute_ReturnsGuardWithMostSleep()
        {
            var guardLogStrings = new[]
            {
                "[1518-05-04 23:59] Guard #523 begins shift",
                "[1518-05-05 00:25] falls asleep",
                "[1518-05-05 00:25] wakes up",
                "[1518-05-05 23:59] Guard #524 begins shift",
                "[1518-05-06 00:25] falls asleep",
                "[1518-05-06 00:26] wakes up",
            };

            var result = _subject.FindSleepiestGuardAndMinute(guardLogStrings);

            Assert.Equal(524, result.guardId);
            Assert.Equal(25, result.minute);
        }

        [Fact]
        public void FindSleepiestGuardAndMinute_ReturnsGuardWithMostSleepOverMultipleBlocks()
        {
            var guardLogStrings = new[]
            {
                "[1518-05-04 23:59] Guard #523 begins shift",
                "[1518-05-05 00:25] falls asleep",
                "[1518-05-05 00:27] wakes up",
                "[1518-05-05 00:26] falls asleep",
                "[1518-05-05 00:28] wakes up",
                "[1518-05-05 23:59] Guard #524 begins shift",
                "[1518-05-06 00:25] falls asleep",
                "[1518-05-06 00:28] wakes up",
                "[1518-05-06 00:30] falls asleep",
                "[1518-05-06 00:31] wakes up",
                "[1518-05-06 23:59] Guard #524 begins shift",
                "[1518-05-07 00:26] falls asleep",
                "[1518-05-07 00:27] wakes up",
            };

            var result = _subject.FindSleepiestGuardAndMinute(guardLogStrings);

            Assert.Equal(524, result.guardId);
            Assert.Equal(26, result.minute);
        }

        [Fact]
        public void FindSleepiestGuardAndMinute_HandlesInputOutOfOrder()
        {
            var guardLogStrings = new[]
            {
                "[1518-05-07 00:29] wakes up",
                "[1518-05-06 23:59] Guard #524 begins shift",
                "[1518-05-05 00:25] falls asleep",
                "[1518-05-05 23:59] Guard #524 begins shift",
                "[1518-05-05 00:28] wakes up",
                "[1518-05-06 00:25] falls asleep",
                "[1518-05-05 00:30] falls asleep",
                "[1518-05-07 00:26] falls asleep",
                "[1518-05-04 23:59] Guard #523 begins shift",
                "[1518-05-05 00:31] wakes up",
                "[1518-05-06 00:27] wakes up",
            };

            var result = _subject.FindSleepiestGuardAndMinute(guardLogStrings);

            Assert.Equal(524, result.guardId);
            Assert.Equal(26, result.minute);
        }

        [Fact]
        public async void FindSleepiestGuardAndMinute_CanFindSolutionForAdventOfCode()
        {
            var input = await new AdventOfCodeClient().GetLines("day/4/input");
            var result = _subject.FindSleepiestGuardAndMinute(input);
            _output.WriteLine("guardId : {0}, minute : {1}, product : {2}", result.guardId, result.minute, result.guardId * result.minute);
        }

        [Fact]
        public void FindMostConsistentlySleepyGuardAndMinute_ReturnsMostFrequentSleepingMinuteForAnIndividualGuard()
        {
            var guardLogStrings = new[]
            {
                "[1518-05-04 23:59] Guard #523 begins shift",
                "[1518-05-05 00:25] falls asleep",
                "[1518-05-05 00:27] wakes up",
                "[1518-05-04 23:59] Guard #523 begins shift",
                "[1518-05-05 00:25] falls asleep",
                "[1518-05-05 00:35] wakes up",
                "[1518-05-05 23:59] Guard #524 begins shift",
                "[1518-05-06 00:25] falls asleep",
                "[1518-05-06 00:28] wakes up",
                "[1518-05-06 00:30] falls asleep",
                "[1518-05-06 00:31] wakes up",
                "[1518-05-06 23:59] Guard #524 begins shift",
                "[1518-05-07 00:26] falls asleep",
                "[1518-05-07 00:27] wakes up",
                "[1518-05-07 23:59] Guard #524 begins shift",
                "[1518-05-07 00:26] falls asleep",
                "[1518-05-07 00:28] wakes up",
            };

            var result = _subject.FindMostConsistentlySleepyGuardAndMinute(guardLogStrings);

            Assert.Equal(524, result.guardId);
            Assert.Equal(26, result.minute);
        }

        [Fact]
        public async void FindMostConsistentlySleepyGuardAndMinute_CanFindSolutionForAdventOfCode()
        {
            var input = await new AdventOfCodeClient().GetLines("day/4/input");
            var result = _subject.FindMostConsistentlySleepyGuardAndMinute(input);
            _output.WriteLine("guardId : {0}, minute : {1}, product : {2}", result.guardId, result.minute, result.guardId * result.minute);
        }
    }
}
