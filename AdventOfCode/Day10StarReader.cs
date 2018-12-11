using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day10StarReader
    {
        public (string[] message, long seconds) GetAlignedStars(IEnumerable<string> positionAndVelocityStrings)
        {
            var stars = ParseStars(positionAndVelocityStrings).ToArray();

            var currentArea = GetArea(stars.Select(star => star.Position).ToList());
            var previousArea = currentArea;
            var closestPositions = new List<Pair>();

            var seconds = 0;
            while (currentArea <= previousArea)
            {
                previousArea = currentArea;
                closestPositions = stars.Select(star => star.Position).ToList();

                MoveStars(stars);

                currentArea = GetArea(stars.Select(star => star.Position).ToList());
                seconds++;
            }

            return (Plot(closestPositions), seconds - 1);
        }

        private IEnumerable<Star> ParseStars(IEnumerable<string> positionAndVelocityStrings)
        {
            return positionAndVelocityStrings.Select(positionAndVelocity =>
            {
                var matches = new Regex("<([^>]+)>").Matches(positionAndVelocity).ToList();
                var positionPair = matches.First().Groups[1].Value.Split(",");
                var velocityPair = matches.Last().Groups[1].Value.Split(",");

                return new Star
                {
                    Position = new Pair
                    {
                        x = int.Parse(positionPair[0].Trim()),
                        y = int.Parse(positionPair[1].Trim())
                    },
                    Velocity = new Pair
                    {
                        x = int.Parse(velocityPair[0].Trim()),
                        y = int.Parse(velocityPair[1].Trim())
                    },
                };
            });
        }

        private string[] Plot(List<Pair> positions)
        {
            var boundaries = GetBoundaries(positions.ToList());

            var grid = new List<char[]>();
            for (var row = 0; row < boundaries.maxY - boundaries.minY + 1; row++)
            {
                grid.Add(Enumerable.Repeat('.', boundaries.maxX - boundaries.minX + 1).ToArray());
            }

            foreach (var position in positions)
            {
                grid[position.y - boundaries.minY][position.x - boundaries.minX] = '#';
            }

            return grid.Select(line => string.Concat(line)).ToArray();
        }

        private (int minX, int maxX, int minY, int maxY) GetBoundaries(List<Pair> positions)
        {
            var xs = positions.Select(position => position.x).ToList();
            var ys = positions.Select(position => position.y).ToList();

            return (xs.Min(), xs.Max(), ys.Min(), ys.Max());
        }

        private long GetArea(List<Pair> positions)
        {
            var boundaries = GetBoundaries(positions);

            return (long) (boundaries.maxX - boundaries.minX) *
                   (boundaries.maxY - boundaries.minY);
        }

        private void MoveStars(Star[] stars)
        {
            for (var index = 0; index < stars.Length; index++)
            {
                stars[index].Position = new Pair
                {
                    x = stars[index].Position.x + stars[index].Velocity.x,
                    y = stars[index].Position.y + stars[index].Velocity.y
                };;
            }
        }

        internal struct Star
        {
            internal Pair Position, Velocity;
        }

        internal struct Pair
        {
            internal int x, y;
        }
    }
}
