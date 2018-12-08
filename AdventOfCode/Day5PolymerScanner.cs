
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day5PolymerScanner
    {
        public int CountUnits(string polymerString)
        {
            return RemoveReactingUnitPair(polymerString).Length;
        }

        public int CountReducedUnits(string polymerString)
        {
            var lowercase = Enumerable.Range('a', 'z' - 'a' + 1).Select(character => (char) character).ToArray();
            var uppercase = Enumerable.Range('A', 'Z' - 'A' + 1).Select(character => (char) character).ToArray();

            var counts = new Dictionary<char, int>();
            for (var index = 0; index < lowercase.Length; index++)
            {
                var count = RemoveReactingUnitPair(polymerString
                    .Replace(lowercase[index].ToString(), "")
                    .Replace(uppercase[index].ToString(), "")).Length;
                counts[lowercase[index]] = count;
            }

            return counts.Values.Min();
        }

        private string RemoveReactingUnitPair(string polymerString)
        {
            var newString = polymerString;
            while (true)
            {
                var indexToRemove = FindIndexToRemove(newString);

                if (!indexToRemove.HasValue)
                {
                    break;
                }

                newString = newString.Substring(0, indexToRemove.Value) +
                            newString.Substring(indexToRemove.Value + 2);
            }

            return newString;
        }

        private int? FindIndexToRemove(string polymerString)
        {
            for (var index = 0; index < polymerString.Length - 1; index++)
            {
                if (char.IsUpper(polymerString[index]) &&
                    char.IsLower(polymerString[index + 1]) &&
                    polymerString[index] == char.ToUpper(polymerString[index + 1]) ||
                    char.IsLower(polymerString[index]) &&
                    char.IsUpper(polymerString[index + 1]) &&
                    polymerString[index] == char.ToLower(polymerString[index + 1]))
                {
                    return index;
                }
            }

            return null;
        }
    }
}
