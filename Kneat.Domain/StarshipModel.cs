using System;
using System.Collections.Generic;
using System.Text;

namespace Kneat.Domain
{
    public class StarshipModel
    {
        public string Name { get; set; }
        public string MGLT { get; set; }
        public string Consumables { get; set; }

        public int ConsumablesInHours { get; set; }
        public double? AmountOfStops { get; set; }
    }
}
