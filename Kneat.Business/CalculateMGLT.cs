using static Kneat.Helper.CustomExceptions;
using static Kneat.Helper.HerperExtension;
using System;

namespace Kneat.Business
{
    public static class CalculateMGLT
    {
        /// <summary>
        /// Method to calculate the Amout of Stops
        /// </summary>
        /// <param name="distance"> Distance in mega lights</param>
        /// <param name="starshipMGLT">Mega lights startship fly per hour</param>
        /// <param name="calculatedHours">Amount of hours the starship can fly without resupply</param>
        /// <returns></returns>
        public static double CalculateAmountOfStops(double distance, int starshipMGLT, int calculatedHours)
        {
            double totalMGLT = starshipMGLT * calculatedHours;
            return Math.Floor(distance / totalMGLT);
        }

        /// <summary>
        /// Method to validate the user input
        /// </summary>
        /// <param name="input">User input</param>
        /// <returns>The same value converted to double</returns>
        public static double ValidMGLTInput(string input)
        {
            double MGLT;
            if (!Double.TryParse(input, out MGLT))
            {
                throw new InputNotANumberException(InputNotANumberMsg);
            }
            else
            {
                MGLT = Convert.ToDouble(input);
            }

            if (MGLT < 0)
            {
                throw new InputNegativeValueException(InputNegativeValueMsg);
            }

            return MGLT;
        }

        /// <summary>
        /// Method to convert starship consumables to hours
        /// </summary>
        /// <param name="consumables">Starship consumables</param>
        /// <returns>INT containing the amount of hours</returns>
        public static int ConsumablesToHours(string consumables)
        {
            int numberOfHours = 0;

            string[] splitedConsumables = consumables.Split(" ");

            switch (splitedConsumables[1].ToLower())
            {
                case "days":
                case "day":
                    numberOfHours = Convert.ToInt16(splitedConsumables[0]) * 24;
                    break;
                case "weeks":
                case "week":
                    numberOfHours = (Convert.ToInt16(splitedConsumables[0]) * 7) * 24;
                    break;
                case "months":
                case "month":
                    numberOfHours = (Convert.ToInt16(splitedConsumables[0]) * 30) * 24; //Considering all months have 30 days
                    break;
                case "years":
                case "year":
                    numberOfHours = (Convert.ToInt16(splitedConsumables[0]) * 365) * 24; //Considering all years have 365 days
                    break;
            }

            return numberOfHours;
        }

        /// <summary>
        /// Method to validate if the consumables are correct before convert them to hours
        /// </summary>
        /// <param name="consumables">Starship consumables</param>
        /// <returns>Return true or a exception</returns>
        public static bool ValidateConsumable(string consumables)
        {
            string validValues = "days|day|weeks|week|months|month|years|year";
            string[] splitedConsumables = consumables.Split(" ");
            int number;

            if (splitedConsumables.Length >= 3)
            {
                throw new ConsumableWrongFormatException(ConsumableWrongFormatMsg);
            }

            if (!int.TryParse(splitedConsumables[0], out number))
            {
                throw new ConsumableFirstValueNotANumberException(ConsumableFirstValueNotANumberMsg);
            }

            if (!validValues.Contains(splitedConsumables[1]))
            {
                throw new ConsumableSecondValueNotRecognizedException(ConsumableSecondValueNotRecognizedMsg);
            }

            return true;
        }
    }
}