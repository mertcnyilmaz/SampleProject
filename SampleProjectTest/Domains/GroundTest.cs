using SampleProject.Enums;
using SampleProject.Exceptions;
using SampleProject.Domains;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SampleProjectTest.Domains
{
    public class GroundTest
    {
        [Fact]
        public void ShouldThrowExceptionWhenRoverNull()
        {
            //Fact
            var result = Assert.Throws<BusinessException>(() => new Ground(null,5,5));
            //Assert
            Assert.Equal("Rovers be not null!", result.Message);
        }

        [Fact]
        public void ShouldThrowExceptionWhenXCoordinateNegative()
        {
            //Arrange
            var rover = new Rover(3, 3, "N", "LMLM");
            var rovers = new List<Rover>();
            rovers.Add(rover);
            //Fact
            var result = Assert.Throws<BusinessException>(() => new Ground(rovers, -1, 5));
            //Assert
            Assert.Equal("Coordinates cannot be negative!", result.Message);
        }

        [Fact]
        public void ShouldThrowExceptionWhenYCoordinateNegative()
        {
            //Arrange
            var rover = new Rover(3, 3, "N", "LMLM");
            var rovers = new List<Rover>();
            rovers.Add(rover);
            //Fact
            var result = Assert.Throws<BusinessException>(() => new Ground(rovers, 5, -1));
            //Assert
            Assert.Equal("Coordinates cannot be negative!", result.Message);
        }

        [Fact]
        public void ShouldThrowExceptionWhenRoverOutsideArea()
        {
            //Arrange
            var rover = new Rover(4, 4, "N", "MMLM");
            var rovers = new List<Rover>();
            rovers.Add(rover);
            var ground = new Ground(rovers, 5, 5);
            //Fact
            var result = Assert.Throws<BusinessException>(() => ground.StartTrip());
            //Assert
            Assert.Equal("Outside the rover area!", result.Message);
        }

        [Fact]
        public void ShouldThrowExceptionWhenInvalidRoverRoute()
        {
            //Arrange
            var rover = new Rover(2, 2, "N", "LMLX");
            var rovers = new List<Rover>();
            rovers.Add(rover);
            var ground = new Ground(rovers, 5, 5);
            //Fact
            var result = Assert.Throws<BusinessException>(() => ground.StartTrip());
            //Assert
            Assert.Equal("Type not found!", result.Message);
        }

        [Fact]
        public void ShouldTheRoverCompleteTrip()
        {
            //Arrange
            var rover = new Rover(2, 2, "N", "LMLRM");
            var rovers = new List<Rover>();
            rovers.Add(rover);
            var ground = new Ground(rovers, 5, 5);
            //Fact
            ground.StartTrip();
            //Assert
            var afterRover = ground.Rovers.FirstOrDefault();
            Assert.True(afterRover != default(Rover) && afterRover.Direction == DirectionTypes.West && afterRover.XCoordinate == 0 && afterRover.YCoordinate == 2);
        }

    }
}
