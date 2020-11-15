using SampleProject.Enums;
using SampleProject.Exceptions;
using SampleProject.Domains;
using Xunit;

namespace SampleProjectTest.Domains
{
    public class RoverTest
    {
        [Fact]
        public void ShouldThrowExceptionWhenRoverXCoordinateNegative()
        {
            //Fact
            var result = Assert.Throws<BusinessException>(() => new Rover(-1,1,"L","LMLM"));
            //Assert
            Assert.Equal("Coordinates cannot be negative!", result.Message);
        }

        [Fact]
        public void ShouldThrowExceptionWhenRoverYCoordinateNegative()
        {
            //Fact
            var result = Assert.Throws<BusinessException>(() => new Rover(1, -1, "L", "LMLM"));
            //Assert
            Assert.Equal("Coordinates cannot be negative!", result.Message);
        }

        [Fact]
        public void ShouldThrowExceptionWhenRoverDirectionNull()
        {
            //Fact
            var result = Assert.Throws<BusinessException>(() => new Rover(1, 1, null, "LMLM"));
            //Assert
            Assert.Equal("Direction cannot be null!", result.Message);
        }

        [Fact]
        public void ShouldThrowExceptionWhenRoverDirectionEmpty()
        {
            //Fact
            var result = Assert.Throws<BusinessException>(() => new Rover(1, 1, string.Empty, "LMLM"));
            //Assert
            Assert.Equal("Direction cannot be null!", result.Message);
        }

        [Fact]
        public void ShouldThrowExceptionWhenInvalidRoverDirection()
        {
            //Fact
            var result = Assert.Throws<BusinessException>(() => new Rover(1, 1, "SAMPLE", "LMLM"));
            //Assert
            Assert.Equal("Type not found!", result.Message);
        }

        [Fact]
        public void ShouldCreateRover()
        {
            //Arrange
            var rover = new Rover(1, 1, "E", "LMLMLM");
            //Assert
            Assert.True(rover.Direction == SampleProject.Enums.DirectionTypes.East && string.Equals(rover.Route,"LMLMLM") && rover.XCoordinate == 1 && rover.YCoordinate == 1);
        }

        [Fact]
        public void ShouldTheRoverTurnLeftWhileLookingNorth()
        {
            //Arrange 
            var rover = new Rover(2, 3, "N", "LMLM");

            //Fact
            rover.TurnLeft();

            //Assert
            Assert.True(rover.Direction == DirectionTypes.West && rover.XCoordinate == 2 && rover.YCoordinate == 3);
        }

        [Fact]
        public void ShouldTheRoverTurnRightWhileLookingWest()
        {
            //Arrange 
            var rover = new Rover(3, 5, "W", "RMLM");

            //Fact
            rover.TurnRight();

            //Assert
            Assert.True(rover.Direction == DirectionTypes.North && rover.XCoordinate == 3 && rover.YCoordinate == 5);
        }

        [Fact]
        public void ShouldTheRoverTurnLeftWhileLookingOutsideNorth()
        {
            //Arrange 
            var rover = new Rover(2, 3, "E", "LMLM");

            //Fact
            rover.TurnLeft();

            //Assert
            Assert.True(rover.Direction == DirectionTypes.North && rover.XCoordinate == 2 && rover.YCoordinate == 3);
        }

        [Fact]
        public void ShouldTheRoverTurnRightWhileLookingOutsideWest()
        {
            //Arrange 
            var rover = new Rover(3, 5, "S", "RMLM");
            //Fact
            rover.TurnRight();
            //Assert
            Assert.True(rover.Direction == DirectionTypes.West && rover.XCoordinate == 3 && rover.YCoordinate == 5);
        }

        [Fact]
        public void ShouldTheRoverWalkToNorth()
        {
            //Arrange 
            var rover = new Rover(3, 5, "N", "M");
            //Fact
            rover.Walk();
            //Assert
            Assert.True(rover.Direction == DirectionTypes.North && rover.XCoordinate == 3 && rover.YCoordinate == 6);
        }

        [Fact]
        public void ShouldTheRoverWalkToWest()
        {
            //Arrange 
            var rover = new Rover(3, 5, "W", "M");
            //Fact
            rover.Walk();
            //Assert
            Assert.True(rover.Direction == DirectionTypes.West && rover.XCoordinate == 2 && rover.YCoordinate == 5);
        }

        [Fact]
        public void ShouldTheRoverWalkToEast()
        {
            //Arrange 
            var rover = new Rover(3, 5, "E", "M");
            //Fact
            rover.Walk();
            //Assert
            Assert.True(rover.Direction == DirectionTypes.East && rover.XCoordinate == 4 && rover.YCoordinate == 5);
        }

        [Fact]
        public void ShouldTheRoverWalkToSouth()
        {
            //Arrange 
            var rover = new Rover(3, 5, "S", "M");
            //Fact
            rover.Walk();
            //Assert
            Assert.True(rover.Direction == DirectionTypes.South && rover.XCoordinate == 3 && rover.YCoordinate == 4);
        }

    }
}
