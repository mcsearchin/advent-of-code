using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day3FabricClaimCalculator
    {
        public int CalculateTotalOverlapping(IEnumerable<string> claimStrings)
        {
            var pointCounts = new Dictionary<string, int>();
            var claims = claimStrings.Select(ParseClaim);
            foreach (var claim in claims)
            {
                var points = GetPoints(claim.x, claim.RightSide, claim.y, claim.BottomSide);
                foreach (var point in points)
                {
                    pointCounts[point] = pointCounts.GetValueOrDefault(point) + 1;
                }
            }
            return pointCounts.Values.Where(count => count > 1).ToList().Count;
        }

        private Claim ParseClaim(string claimString)
        {
            var numbers = Regex.Matches(claimString, "[0-9]+").ToArray();
            return new Claim
            {
                id = int.Parse(numbers[0].Value),
                x = int.Parse(numbers[1].Value),
                y = int.Parse(numbers[2].Value),
                width = int.Parse(numbers[3].Value),
                height = int.Parse(numbers[4].Value)
            };
        }

        private string[] GetPoints(int x1, int x2, int y1, int y2)
        {
            return Enumerable.Range(x1, x2 - x1)
                .SelectMany(x => Enumerable.Range(y1, y2 - y1),
                    (x, y) => $"{x},{y}")
                .ToArray();
        }
    }

    internal struct Claim
    {
        internal int id, x, y, width, height;

        internal int RightSide => x + width;

        internal int BottomSide => y + height;
    }
}
