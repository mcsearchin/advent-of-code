namespace AdventOfCode
{
    public class Day11MaxPowerFinder
    {
        private const int GridWidth = 300;
        private const int GridHeight = 300;

        public (int x, int y) FindMaxPowerSquareCoordinates(int serialNumber)
        {
            var grid = BuildPowerGrid(serialNumber);
            int? maxPower = null;
            var maxPowerSquareTopLeft = (0, 0);

            for (var row = 0; row < grid.Length - 2; row++)
            {
                for (var col = 0; col < grid[row].Length - 2; col++)
                {
                    var squareSum = grid[row][col] + grid[row][col + 1] + grid[row][col + 2] +
                                    grid[row + 1][col] + grid[row + 1][col + 1] + grid[row + 1][col + 2] +
                                    grid[row + 2][col] + grid[row + 2][col + 1] + grid[row + 2][col + 2];

                    if (!maxPower.HasValue || maxPower.Value < squareSum)
                    {
                        maxPower = squareSum;
                        maxPowerSquareTopLeft = (col + 1, row + 1);
                    }
                }
            }

            return maxPowerSquareTopLeft;
        }

        private int[][] BuildPowerGrid(int serialNumber)
        {
            var grid = new int[GridHeight][];
            for (var row = 0; row < grid.Length; row++)
            {
                grid[row] = new int[GridWidth];
                for (var col = 0; col < grid[row].Length; col++)
                {
                    grid[row][col] = CalculatePowerLevel(col + 1, row + 1, serialNumber);
                }
            }

            return grid;
        }

        private int CalculatePowerLevel(int x, int y, int serialNumber)
        {
            var rackId = x + 10;
            var powerLevel = rackId * y;
            powerLevel += serialNumber;
            powerLevel *= rackId;
            powerLevel = (powerLevel / 100) % 10;
            powerLevel -= 5;
            return powerLevel;
        }
    }
}
