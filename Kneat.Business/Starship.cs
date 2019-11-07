using Kneat.Domain;
using Kneat.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kneat.Business
{
    public static class Starship
    {
        public static List<StarshipModel> GetStarshipsAsync() => Swapi.GetStarshipsAsync().Result;
    }
}
