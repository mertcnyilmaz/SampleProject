using SampleProject.Consts;
using SampleProject.Enums;
using SampleProject.Exceptions;
using SampleProject.Helpers;

namespace SampleProject.Domains
{
    public class Rover
    {
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public DirectionTypes Direction { get; private set; }
        public string Route { get; private set; }

        public Rover(int xCoordinate, int yCoordinate, string direction, string route)
        {

            if (xCoordinate < 0 || yCoordinate < 0)
            {
                throw new BusinessException(ExceptionMessageConsts.COORDINATES_CANNOT_BE_NEGATIVE_MESSAGE);
            }

            if(string.IsNullOrWhiteSpace(direction))
            {
                throw new BusinessException(ExceptionMessageConsts.DIRECTION_CANNOT_BE_NULL_MESSAGE);
            }

            if(string.IsNullOrWhiteSpace(route))
            {
                throw new BusinessException(ExceptionMessageConsts.ROUTE_CANNOT_BE_NULL_MESSAGE);
            }

            Route = route;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Direction = EnumHelper.GetValueFromDescription<DirectionTypes>(direction);
        }

        public void TurnLeft()
            => Direction = Direction == DirectionTypes.North ? DirectionTypes.West : Direction - 1;

        public void TurnRight()
            => Direction = Direction == DirectionTypes.West ? DirectionTypes.North : Direction + 1;

        public void Walk()
        {
            switch (Direction)
            {
                case DirectionTypes.North:
                    ++YCoordinate;
                    break;
                case DirectionTypes.East:
                    ++XCoordinate;
                    break;
                case DirectionTypes.South:
                    --YCoordinate;
                    break;
                case DirectionTypes.West:
                    --XCoordinate;
                    break;
            }

        }
    }
}
