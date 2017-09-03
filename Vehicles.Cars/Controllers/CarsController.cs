using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vehicles.Cars.Model;
using System.Data;
using Vehicles.Persistence;

namespace Vehicles.Cars.Controllers
{
    [Route("vehicles/[controller]")]
    public class CarsController : Controller
    {
        private CarsRepository repository;

        public CarsController(IDbConnection connection)
        {
            this.repository = new CarsRepository(connection);

        }

        [HttpGet]
        public IEnumerable<Car> GetAll()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Car car)
        {
            repository.Insert(car);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Car car)
        {
            repository.Update(car);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Delete(new Car() { Id = id });
        }
    }
}
