using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.Persistence;

namespace Vehicles.Trucks.Model
{
    public class TrucksRepository : GenericRepository<Truck>
    {
        public TrucksRepository(IDbConnection connection) : base(connection) { }
    }
}
