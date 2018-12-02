using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day1FrequencyCalculator
    {
        public long CalculateChange(string frequencyChangesString)
        {
            return ParseFrequencyChanges(frequencyChangesString).Sum();
        }

        public long FindFirstDuplicateFrequency(string frequencyChangesString)
        {
            var summedChanges = new long[] {0}.ToList();

            while (true)
            {
                foreach (var frequencyChange in ParseFrequencyChanges(frequencyChangesString))
                {
                    var lastSum = summedChanges.LastOrDefault();
                    var newSum = lastSum + frequencyChange;
                    if (summedChanges.Contains(newSum))
                    {
                        return newSum;
                    }

                    summedChanges.Add(newSum);
                }
            }
        }

        private IEnumerable<long> ParseFrequencyChanges(string frequencyChangesString)
        {
            long unusedParsedLong;
            return frequencyChangesString
                .Split("\n")
                .ToList()
                .Where(line => long.TryParse(line, out unusedParsedLong))
                .Select(line => long.Parse(line));
        }
    }
}
