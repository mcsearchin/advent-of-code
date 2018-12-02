using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day2BoxIdChecksumCalculator
    {
        public int CalculateChecksum(string boxIdsString)
        {
            var counts = boxIdsString
                .Split("\n")
                .Aggregate((0, 0), CountTwoAndThreeOccurrences);

            return counts.Item1 * counts.Item2;
        }

        private (int containedExactlyTwo, int containedExactlyThree) CountTwoAndThreeOccurrences(
            (int containedExactlyTwo, int containedExactlyThree) totals, string boxId)
        {
            var characterOccurrences = GetCharacterOccurrences(boxId);
            return (totals.containedExactlyTwo + (characterOccurrences.ContainsValue(2) ? 1 : 0),
                    totals.containedExactlyThree + (characterOccurrences.ContainsValue(3) ? 1 : 0));
        }

        private Dictionary<char, int> GetCharacterOccurrences(string boxId)
        {
            var characterOccurrences = new Dictionary<char, int>();
            foreach (var character in boxId)
            {
                var currentCount = characterOccurrences.GetValueOrDefault(character);
                characterOccurrences[character] = currentCount + 1;
            }

            return characterOccurrences;
        }
    }
}
