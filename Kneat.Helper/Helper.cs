using System;
using System.Threading.Tasks;

namespace Kneat.Helper
{
    public static class HerperExtension
    {
        public static string StarshipsURL = "https://swapi.co/api/starships/";

        public static readonly string InputNotANumberMsg = "Mega lights needs to be a number.";
        public static readonly string InputNegativeValueMsg = "Might lights needs to be higher than 0.";
        public static readonly string ConsumableWrongFormatMsg = "Starship consumable is in wrong format";
        public static readonly string ConsumableFirstValueNotANumberMsg = "Starship consumable first value needs to be a number";
        public static readonly string ConsumableSecondValueNotRecognizedMsg = "Starship consumable second value should be year, day or month";
        public static readonly string NullSpaceshipShipURLMsg = "Invalid Starship URL";
    }
}
