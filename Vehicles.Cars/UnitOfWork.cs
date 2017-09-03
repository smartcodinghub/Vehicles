using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.Cars.Model;
using Vehicles.Persistence;

namespace Vehicles.Cars
{
    public class UnitOfWork : UnitOfWorkBase
    {
        private CarsRepository carsRepository;

        public UnitOfWork(IDbConnection connection) : base(connection) { }

        public CarsRepository CarsRepository => carsRepository ?? (carsRepository = new CarsRepository(connection));
    }
}
