using Kneat.Business;
using Kneat.Helper;
using System;
using Xunit;

namespace Kneat.Tests
{
    public class MGLTTest
    {
        [Theory]
        [InlineData(1000000, "75", 1440, 9)]  //Millennium Falcon
        [InlineData(1000000, "80", 168, 74)]  //Y-wing
        [InlineData(1000000, "50", 1440, 13)] //Imperial shuttle
        public void CalculateAmountofStopsTest(double distance, string MGLT, int hours, int expectedResult)
        {
            double amountOfStops = CalculateMGLT.CalculateAmountOfStops(distance, Convert.ToInt32(MGLT), hours);

            Assert.Equal(expectedResult, amountOfStops);
        }

        [Theory]
        [InlineData("1 year", 8760)]    //CR90 corvette
        [InlineData("2 days", 48)]      //Jedi Interceptor
        [InlineData("6 months", 4320)]  //Rebel transport
        public void ConvertConsumablesToHoursTest(string consumables, int? expectedResult)
        {
            int? hours = CalculateMGLT.ConsumablesToHours(consumables);

            Assert.Equal(expectedResult, hours);
        }

        [Fact]
        public void ConsumableWrongFormatTest_ShouldThrowConsumableWrongFormatException()
        {
            Assert.Throws<CustomExceptions.ConsumableWrongFormatException>(() 
                => CalculateMGLT.ValidateConsumable("1 test wrong"));
        }

        [Fact]
        public void ConsumableNotNumberFirstTest_ShouldThrowConsumableFirstValueNotANumberException()
        {
            Assert.Throws<CustomExceptions.ConsumableFirstValueNotANumberException>(()
                => CalculateMGLT.ValidateConsumable("week 1"));
        }

        [Fact]
        public void ConsumableSecondValueNotValidTest_ShouldThrowConsumableSecondValueNotRecognizedException()
        {
            Assert.Throws<CustomExceptions.ConsumableSecondValueNotRecognizedException>(()
                => CalculateMGLT.ValidateConsumable("50 megatons"));
        }
    }
}
