using SampleProject.Consts;
using SampleProject.Exceptions;
using SampleProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleProject
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var groundInformations = Console.ReadLine();
                var groundItems = groundInformations.Split(' ');

                if (groundItems == default(string[]) || !groundItems.Any() || groundItems.Length != BusinessConsts.GROUND_INPUT_LINE_SEPERATED_ITEMS_COUNT)
                {
                    throw new BusinessException(ExceptionMessageConsts.INCORRECT_INPUT_MESSAGE);
                }

                var validateTemp = 0;

                if (!(Int32.TryParse(groundItems[0], out validateTemp) && Int32.TryParse(groundItems[1], out validateTemp)))
                {
                    throw new BusinessException(ExceptionMessageConsts.INVALID_INPUT_MESSAGE);
                }

                List<Rover> rovers = new List<Rover>();
                var roverInput = string.Empty;
                var route = string.Empty;
                var roverItems = default(string[]);

                while (true)
                {
                    roverInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(roverInput))
                    {
                        break;
                    }

                    route = Console.ReadLine();
                    roverItems = roverInput.Split(' ');

                    if (roverItems == default(string[]) || !roverItems.Any() || roverItems.Length != BusinessConsts.ROVER_INPUT_LINE_SEPERATED_ITEMS_COUNT)
                    {
                        throw new BusinessException(ExceptionMessageConsts.INCORRECT_INPUT_MESSAGE);
                    }

                    if (Int32.TryParse(roverItems[0], out validateTemp) && Int32.TryParse(roverItems[1], out validateTemp) && !string.IsNullOrWhiteSpace(roverItems[2]) && roverItems[2].ToArray().Length != 1)
                    {
                        throw new BusinessException(ExceptionMessageConsts.INVALID_INPUT_MESSAGE);
                    }

                    rovers.Add(new Rover(Convert.ToInt32(roverItems[0]), Convert.ToInt32(roverItems[1]), roverItems[2], route));
                }

                Ground ground = new Ground(rovers, Convert.ToInt32(groundItems[0]), Convert.ToInt32(groundItems[1]));

                ground.StartTrip();
                ground.WriteRoversCoordinates();

            }
            catch(BusinessException businessEx)
            {
                Console.WriteLine("Business exception : " + businessEx.Message);
            }
            catch(Exception)
            {
                return;
            }

            Console.ReadLine();

        }
    }


}
