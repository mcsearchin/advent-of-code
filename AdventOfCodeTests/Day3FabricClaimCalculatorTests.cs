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

        [Fact]
        public void
            CalculateTotalOverlapping_ReturnsTheOverlappingAreaWhenAClaimOverlapsByMoreThanOneAtTheRightAndBottom()
        {
            var claims = new[] {"#1 @ 2,2: 3x3", "#2 @ 3,3: 3x3"};

            Assert.Equal(4, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public void CalculateTotalOverlapping_ReturnsTheOverlappingAreaOneWhenAClaimOverlapsByMoreThanOneAtTheLeftAndBottom()
        {
            var claims = new[] {"#1 @ 2,2: 3x3", "#2 @ 1,4: 3x3"};

            Assert.Equal(2, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public void
            CalculateTotalOverlapping_ReturnsTheOverlappingAreaWhenAClaimOverlapsByMoreThanOneAtTheRightAndTop()
        {
            var claims = new[] {"#1 @ 2,2: 3x3", "#2 @ 3,0: 3x3"};

            Assert.Equal(2, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public void CalculateTotalOverlapping_ReturnsTheOverlappingAreaOneWhenAClaimOverlapsByMoreThanOneAtTheLeftAndTop()
        {
            var claims = new[] {"#1 @ 2,2: 3x3", "#2 @ 1,1: 3x3"};

            Assert.Equal(4, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public void CalculateTotalOverlapping_ReturnsOverlapsForMoreThanTwoClaims()
        {
            var claims = new[] {"#1 @ 0,0: 2x2", "#2 @ 1,1: 2x2", "#3 @ 2,2: 2x2"};

            Assert.Equal(2, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public void CalculateTotalOverlapping_DoesNotCountTheSameOverlapMoreThanOnce()
        {
            var claims = new[] {"#1 @ 0,0: 3x3", "#2 @ 1,1: 3x3", "#3 @ 2,2: 3x3", "#4 @ 3,3: 3x3"};

            Assert.Equal(10, _subject.CalculateTotalOverlapping(claims));
        }

        [Fact]
        public async void CalculateTotalOverlapping_CanFindSolutionForAdventOfCode()
        {
            var input = await new AdventOfCodeClient().GetLines("day/3/input");
            var totalOverlapping = _subject.CalculateTotalOverlapping(input);
            _output.WriteLine("totalOverlapping : {0}", totalOverlapping);
        }

        [Fact]
        public void FindNonOverlapping_FindsNothingWhenAllClaimsOverlap()
        {
            var claims = new[] {"#1 @ 0,0: 2x2", "#2 @ 1,1: 2x2", "#3 @ 2,2: 2x2"};

            Assert.Null(_subject.FindNonOverlapping(claims));
        }

        [Fact]
        public void FindNonOverlapping_ReturnsTheOnlyClaimIdWhenASingleClaimIsPassed()
        {
            var claims = new[] {"#43 @ 0,0: 2x2"};

            Assert.Equal(43, _subject.FindNonOverlapping(claims));
        }

        [Fact]
        public void FindNonOverlapping_ReturnsTheNonOverlappingClaimId()
        {
            var claims = new[] {"#1 @ 0,0: 2x2", "#2 @ 1,1: 2x2", "#3 @ 3,3: 2x2"};

            Assert.Equal(3, _subject.FindNonOverlapping(claims));
        }

        [Fact]
        public async void FindNonOverlapping_CanFindSolutionForAdventOfCode()
        {
            var input = await new AdventOfCodeClient().GetLines("day/3/input");
            var nonOverlappingId = _subject.FindNonOverlapping(input);
            _output.WriteLine("nonOverlappingId : {0}", nonOverlappingId);
        }
    }
}
