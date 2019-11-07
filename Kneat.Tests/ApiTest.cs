using Kneat.Helper;
using Kneat.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kneat.Tests
{
    public class ApiTest
    {
        [Fact]
        public async Task NullSpaceshipURL_ShouldThrowNullSpaceshipShipURLException()
        {
            HerperExtension.StarshipsURL = string.Empty;

            await Assert.ThrowsAsync<CustomExceptions.NullSpaceshipShipURLException>(() => Swapi.GetStarshipsAsync());
        }
    }
}