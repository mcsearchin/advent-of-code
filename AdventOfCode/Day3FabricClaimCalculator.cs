using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day3FabricClaimCalculator
    {
        public int CalculateTotalOverlapping(string[] claimStrings)
        {
            if (claimStrings.Length < 2) {return 0;}

            var claims = claimStrings.Select(ParseClaim);
            var overLappingCoordinates = GetOverlappingCoordinates(claims.First(), claims.Last());
            return overLappingCoordinates.Length;
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

        private string[] GetOverlappingCoordinates(Claim first, Claim second)
        {
            if (second.x >= first.x && second.x < first.rightSide &&
                second.y >= first.y && second.y < first.bottomSide)
            {
                return new [] {"overlap"};
            }

            if (second.rightSide > first.x && second.rightSide <= first.rightSide &&
                second.y >= first.y && second.y < first.bottomSide)
            {
                return new [] {"overlap"};
            }

            if (second.x >= first.x && second.x < first.rightSide &&
                second.bottomSide > first.y && second.bottomSide <= first.bottomSide)
            {
                return new [] {"overlap"};
            }

            if (second.rightSide > first.x && second.rightSide <= first.rightSide &&
                second.bottomSide > first.y && second.bottomSide <= first.bottomSide)
            {
                return new [] {"overlap"};
            }

            return new string[] {};
        }
    }

    internal struct Claim
    {
        internal int id, x, y, width, height;

        internal int rightSide
        {
            get
            {
                return x + width;
            }
        }

        internal int bottomSide
        {
            get
            {
                return y + height;
            }
        }
    }
}
