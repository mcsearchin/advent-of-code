using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day4GuardSleepAnalyzer
    {
        private readonly IEnumerable<int> _minutes = Enumerable.Range(0, 60);

        public (int guardId, int minute) FindSleepiestGuardAndMinute(IEnumerable<string> guardLogStrings)
        {
            var sleepBlocks = ParseSleepBlocks(guardLogStrings).ToList();

            var totalSleepByGuard = sleepBlocks
                .GroupBy(sleepBlock => sleepBlock.GuardId)
                .ToDictionary(
                    group => group.Key,
                    group => group.Sum(sleepBlock => sleepBlock.Duration)
                );

            var sleepiestGuard = totalSleepByGuard.First(pair => pair.Value == totalSleepByGuard.Values.Max()).Key;
            var sleepMinuteCounts = CountSleepMinutes(sleepBlocks.Where(sleepBlock => sleepBlock.GuardId == sleepiestGuard));
            var sleepiestMinute = sleepMinuteCounts.First(pair => pair.Value == sleepMinuteCounts.Values.Max()).Key;
            return (sleepiestGuard, sleepiestMinute);
        }

        private IEnumerable<SleepBlock> ParseSleepBlocks(IEnumerable<string> guardLogStrings)
        {
            var sleepBlocks = new List<SleepBlock>();
            var currentBlock = new SleepBlock();
            var orderedLogStrings = guardLogStrings.OrderBy(str => str);
            foreach (var logString in orderedLogStrings)
            {
                if (logString.EndsWith("begins shift"))
                {
                    currentBlock = new SleepBlock()
                    {
                        GuardId = int.Parse(Regex.Match(logString, "(?<=#)[0-9]+").Value)
                    };
                }
                else if (logString.EndsWith("falls asleep"))
                {
                    currentBlock.Start = int.Parse(Regex.Match(logString, "(?<=:)[0-9]+").Value);
                }
                else if (logString.EndsWith("wakes up"))
                {
                    currentBlock.End = int.Parse(Regex.Match(logString, "(?<=:)[0-9]+").Value);
                    sleepBlocks.Add(currentBlock);
                }
            }

            return sleepBlocks;
        }

        private Dictionary<int, int> CountSleepMinutes(IEnumerable<SleepBlock> sleepBlocks)
        {
            var sleepMinuteCounts = new Dictionary<int, int>();

            foreach (var block in sleepBlocks)
            {
                foreach (var minute in _minutes)
                {
                    if (minute >= block.Start && minute < block.End)
                    {
                        sleepMinuteCounts[minute] = sleepMinuteCounts.GetValueOrDefault(minute) + 1;
                    }
                }
            }

            return sleepMinuteCounts;
        }

        internal struct SleepBlock
        {
            internal int GuardId, Start, End;

            internal int Duration => End - Start;
        }
    }
}
