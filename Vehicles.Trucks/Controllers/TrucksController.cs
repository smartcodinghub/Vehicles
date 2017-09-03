using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using Vehicles.Trucks.Model;
using System.Data;

namespace Vehicles.Trucks.Controllers
{
    [Route("vehicles/[controller]")]
    public class TrucksController : Controller
    {
        private TrucksRepository repository;

        public TrucksController(IDbConnection connection)
        {
            this.repository = new TrucksRepository(connection);

        }

        [HttpGet]
        public IEnumerable<Truck> Get()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public Truck Get(int id)
        {
            return repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Truck truck)
        {
            repository.Insert(truck);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Truck truck)
        {
            repository.Update(truck);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Delete(new Truck() { Id = id });
        }
    }
}
