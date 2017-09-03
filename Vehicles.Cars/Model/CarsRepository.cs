using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.Persistence;

namespace Vehicles.Cars.Model
{
    public class CarsRepository : GenericRepository<Car>
    {
        public CarsRepository(IDbConnection connection) : base(connection) { }
    }
}
