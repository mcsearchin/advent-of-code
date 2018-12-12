using AdventOfCode;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCodeTests
{
    public class Day10StarReaderTests
    {
        private readonly Day10StarReader _subject;
        private readonly ITestOutputHelper _output;

        public Day10StarReaderTests(ITestOutputHelper output)
        {
            _output = output;
            _subject = new Day10StarReader();
        }

        [Fact]
        public void GetAlignedStars_WorksForExample()
        {
            var input = new[]
            {
                "position=< 9,  1> velocity=< 0,  2>",
                "position=< 7,  0> velocity=<-1,  0>",
                "position=< 3, -2> velocity=<-1,  1>",
                "position=< 6, 10> velocity=<-2, -1>",
                "position=< 2, -4> velocity=< 2,  2>",
                "position=<-6, 10> velocity=< 2, -2>",
                "position=< 1,  8> velocity=< 1, -1>",
                "position=< 1,  7> velocity=< 1,  0>",
                "position=<-3, 11> velocity=< 1, -2>",
                "position=< 7,  6> velocity=<-1, -1>",
                "position=<-2,  3> velocity=< 1,  0>",
                "position=<-4,  3> velocity=< 2,  0>",
                "position=<10, -3> velocity=<-1,  1>",
                "position=< 5, 11> velocity=< 1, -2>",
                "position=< 4,  7> velocity=< 0, -1>",
                "position=< 8, -2> velocity=< 0,  1>",
                "position=<15,  0> velocity=<-2,  0>",
                "position=< 1,  6> velocity=< 1,  0>",
                "position=< 8,  9> velocity=< 0, -1>",
                "position=< 3,  3> velocity=<-1,  1>",
                "position=< 0,  5> velocity=< 0, -1>",
                "position=<-2,  2> velocity=< 2,  0>",
                "position=< 5, -2> velocity=< 1,  2>",
                "position=< 1,  4> velocity=< 2,  1>",
                "position=<-2,  7> velocity=< 2, -2>",
                "position=< 3,  6> velocity=<-1, -1>",
                "position=< 5,  0> velocity=< 1,  0>",
                "position=<-6,  0> velocity=< 2,  0>",
                "position=< 5,  9> velocity=< 1, -2>",
                "position=<14,  7> velocity=<-2,  0>",
                "position=<-3,  6> velocity=< 2, -1>"
            };

            var expected = new[]
            {
                "#...#..###",
                "#...#...#.",
                "#...#...#.",
                "#####...#.",
                "#...#...#.",
                "#...#...#.",
                "#...#...#.",
                "#...#..###"
            };
            var actual = _subject.GetAlignedStars(input);
            LogLines(actual.message);
            Assert.Equal(expected, actual.message);
            Assert.Equal(3, actual.seconds);
        }

        [Fact]
        public async void GetAlignedStars_CanFindSolutionForAdventOfCode()
        {
            var input = await new AdventOfCodeClient().GetLines("day/10/input");
            var result = _subject.GetAlignedStars(input);
            LogLines(result.message);
            _output.WriteLine("seconds : {0}", result.seconds);
        }

        private void LogLines(string[] lines)
        {
            foreach (var line in lines)
            {
                _output.WriteLine(line);
            }
        }
    }
}
