using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicles.Trucks.Model
{
    public class Truck
    {
        public int Id { get; set; }

        public String Model { get; set; }

        public String Registration { get; set; }

        public String Color { get; set; }

        public int Capacity { get; set; }
    }
}
