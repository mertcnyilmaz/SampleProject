using SampleProject.Consts;
using SampleProject.Enums;
using SampleProject.Exceptions;
using SampleProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleProject.Domains
{
    public class Ground
    {
        public List<Rover> Rovers { get; private set; }
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public Ground(List<Rover> rovers, int xCoordinate, int yCoordinate)
        {

            if (rovers == default(List<Rover>) || !rovers.Any())
            {
                throw new BusinessException(ExceptionMessageConsts.ROVERS_BE_NOT_NULL_MESSAGE);
            }

            if (xCoordinate < 0 || yCoordinate < 0)
            {
                throw new BusinessException(ExceptionMessageConsts.COORDINATES_CANNOT_BE_NEGATIVE_MESSAGE);
            }

            Rovers = rovers;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public void StartTrip()
        {
            foreach (var rover in Rovers)
            {
                GoRover(rover);
            }
        }

        public void WriteRoversCoordinates()
        {
            foreach (var rover in Rovers)
            {
                Console.WriteLine(rover.XCoordinate + " " + rover.YCoordinate + " " + rover.Direction.GetDescription());
            }
        }

        private void GoRover(Rover rover)
        {
            foreach (var command in rover.Route.ToCharArray())
            {

                switch (EnumHelper.GetValueFromDescription<DirectionCommandTypes>(command.ToString()))
                {
                    case DirectionCommandTypes.L:
                        rover.TurnLeft();
                        break;
                    case DirectionCommandTypes.R:
                        rover.TurnRight();
                        break;
                    case DirectionCommandTypes.M:
                        rover.Walk();
                        break;
                    default:
                        throw new BusinessException(ExceptionMessageConsts.UNIDENTIFIED_COMMAND_MESSAGE);
                }

                if (!IsTheRoverInTheArea(rover))
                {
                    throw new BusinessException(ExceptionMessageConsts.OUTSIDE_THE_ROVER_AREA_MESSAGE);
                }
            }
        }

        private bool IsTheRoverInTheArea(Rover rover)
            => rover.XCoordinate <= XCoordinate && rover.XCoordinate >= 0 && rover.YCoordinate <= YCoordinate && rover.YCoordinate >= 0;
    }
}
