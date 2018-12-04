using AdventOfCode;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCodeTests
{
    public class Day3FabricClaimCalculatorTests
    {
        private readonly Day3FabricClaimCalculator _subject;
        private readonly ITestOutputHelper _output;

        public Day3FabricClaimCalculatorTests(ITestOutputHelper output)
        {
            _output = output;
            _subject = new Day3FabricClaimCalculator();
        }

        [Fact]
        public void CalculateTotalOverlapping_ReturnsZeroForASingleClaim()
        {
            var claims = new[] {"#1 @ 0,0: 1x1"};

            Assert.Equal(0, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public void CalculateTotalOverlapping_ReturnsOneForTwoOverlappingOneInchClaims()
        {
            var claims = new[] {"#1 @ 0,0: 1x1", "#2 @ 0,0: 1x1"};

            Assert.Equal(1, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public void CalculateTotalOverlapping_DoesNotCountWhenAClaimIsAdjacentToTheRight()
        {
            var claims = new[] {"#1 @ 0,0: 1x1", "#2 @ 1,0: 1x1"};

            Assert.Equal(0, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public void CalculateTotalOverlapping_ReturnsOneWhenAClaimOverlapsByOneAtTheRight()
        {
            var claims = new[] {"#1 @ 0,0: 2x1", "#2 @ 1,0: 2x1"};

            Assert.Equal(1, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public void CalculateTotalOverlapping_DoesNotCountWhenAClaimIsAdjacentToTheLeft()
        {
            var claims = new[] {"#1 @ 1,0: 1x1", "#2 @ 0,0: 1x1"};

            Assert.Equal(0, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public void CalculateTotalOverlapping_ReturnsOneWhenAClaimOverlapsByOneAtTheLeft()
        {
            var claims = new[] {"#1 @ 1,0: 2x1", "#2 @ 0,0: 2x1"};

            Assert.Equal(1, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public void CalculateTotalOverlapping_DoesNotCountWhenAClaimIsAdjacentToTheBottom()
        {
            var claims = new[] {"#1 @ 0,0: 1x1", "#2 @ 0,1: 1x1"};

            Assert.Equal(0, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public void CalculateTotalOverlapping_ReturnsOneWhenAClaimOverlapsByOneAtTheBottom()
        {
            var claims = new[] {"#1 @ 0,0: 1x2", "#2 @ 0,1: 1x2"};

            Assert.Equal(1, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public void CalculateTotalOverlapping_DoesNotCountWhenAClaimIsAdjacentToTheTop()
        {
            var claims = new[] {"#1 @ 0,1: 1x1", "#2 @ 0,0: 1x1"};

            Assert.Equal(0, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public void CalculateTotalOverlapping_ReturnsOneWhenAClaimOverlapsByOneAtTheTop()
        {
            var claims = new[] {"#1 @ 0,1: 1x2", "#2 @ 0,0: 1x2"};

            Assert.Equal(1, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public void CalculateTotalOverlapping_ReturnsOneWhenAClaimOverlapsByOneAtTheRightAndBottom()
        {
            var claims = new[] {"#1 @ 0,0: 2x2", "#2 @ 1,1: 2x2"};

            Assert.Equal(1, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public void CalculateTotalOverlapping_ReturnsOneWhenAClaimOverlapsByOneAtTheLeftAndBottom()
        {
            var claims = new[] {"#1 @ 1,0: 2x2", "#2 @ 0,1: 2x2"};

            Assert.Equal(1, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public void CalculateTotalOverlapping_ReturnsOneWhenAClaimOverlapsByOneAtTheRightAndTop()
        {
            var claims = new[] {"#1 @ 0,1: 2x2", "#2 @ 1,0: 2x2"};

            Assert.Equal(1, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public void CalculateTotalOverlapping_ReturnsOneWhenAClaimOverlapsByOneAtTheLeftAndTop()
        {
            var claims = new[] {"#1 @ 1,1: 2x2", "#2 @ 0,0: 2x2"};

            Assert.Equal(1, _subject.CalculateTotalOverlapping(claims));
        }
    }
}
