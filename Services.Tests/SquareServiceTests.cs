using Xunit;
using static Services.PointService;

namespace Services.Tests
{
    public class SquareServiceTests
    {
        private readonly SquareService _sut;

        public SquareServiceTests()
        {
            _sut = new SquareService();
        }

        [Fact]
        // FindSquaress (what we have) WithFourSquarePoints (condition) FindOneSquare (result)
        public void FindSquares_WithFourSquarePoints_FindOneSquare()
        {
            //arrange
            var points = new List<Point> { 
                new Point { X = 1, Y = 1 },
                new Point { X = -1, Y = 1},
                new Point { X = 1, Y = -1 },
                new Point { X = -1, Y = -1 }
            };

            //act
            var squares = _sut.FindSquares(points);
            //assert
            Assert.Single(squares);
            // write assert to check if square is from from given points
        }

        [Fact]
        // FindSquaress (what we have) WithFourSquarePoints (condition) FindOneSquare (result)
        public void FindSquares_WithFourRandomPoints_FindNoSquares()
        {
            //arrange
            var points = new List<Point> {
                new Point { X = 1, Y = 0 },
                new Point { X = 7, Y = 1},
                new Point { X = 1, Y = 4 },
                new Point { X = 6, Y = -1 }
            };

            //act
            var squares = _sut.FindSquares(points);
            //assert
            Assert.Empty(squares);
            // write assert to check if square is from from given points
        }
    }
}