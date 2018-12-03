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

        public string FindCommonBoxIdString(string boxIdsString)
        {
            return FindCommonBoxIdString(boxIdsString.Split("\n"));
        }

        private string FindCommonBoxIdString(string[] boxIds)
        {
            if (boxIds.Length < 2) { return null; }

            var boxId = boxIds.First();
            var theRest = boxIds.Skip(1).ToArray();
            var correctOtherId = theRest.FirstOrDefault(otherId => HasSingleNonMatchingCharacter(boxId, otherId));

            if (correctOtherId == null)
            {
                return FindCommonBoxIdString(theRest);
            }

            var nonMatchingIndex = GetSingleNonMatchingIndex(boxId, correctOtherId);

            return nonMatchingIndex.HasValue ? RemoveCharacterAtIndex(correctOtherId, nonMatchingIndex.Value) : null;
        }

        private bool HasSingleNonMatchingCharacter(string first, string second)
        {
            return GetSingleNonMatchingIndex(first, second).HasValue;
        }

        private int? GetSingleNonMatchingIndex(string first, string second)
        {
            int? firstNonMatchingIndex = null;
            int index;
            for (index = 0; index < first.Length && index < second.Length; index++)
            {
                if (first[index] == second[index]) continue;

                if (firstNonMatchingIndex.HasValue) { return null; }

                firstNonMatchingIndex = index;
            }

            return firstNonMatchingIndex;
        }

        private string RemoveCharacterAtIndex(string stringy, int index)
        {
            return stringy.Substring(0, index) +
                   stringy.Substring(index + 1, stringy.Length - index - 1);
        }
    }
}
