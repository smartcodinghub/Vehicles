using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Vehicles.Cars.Model
{
    [Table("CARS")]
    public class Car
    {
        public int Id { get; set; }
        
        public String Model { get; set; }
        
        public String Registration { get; set; }
        
        public String Color { get; set; }
    }
}
