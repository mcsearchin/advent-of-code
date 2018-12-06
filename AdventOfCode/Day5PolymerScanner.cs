
namespace AdventOfCode
{
    public class Day5PolymerScanner
    {
        public int CountUnits(string polymerString)
        {
            return RemoveReactingUnitPair(polymerString.Trim()).Length;
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
