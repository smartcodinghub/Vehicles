using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using Vehicles.Trucks.Model;

namespace Vehicles.Trucks.Controllers
{
    [Route("vehicles/[controller]")]
    public class TrucksController : Controller
    {
        private static readonly ConcurrentDictionary<int, Truck> cars = new ConcurrentDictionary<int, Truck>(
            new Truck[]
            {
                new Truck() { Id = 1, Color = "Green", Model = "Nissan", Registration = "1234 ABC", Capacity = 20 },
                new Truck() { Id = 2, Color = "Red", Model = "Nissan", Registration = "1234 ABC", Capacity = 20 },
                new Truck() { Id = 3, Color = "Blue", Model = "Nissan", Registration = "1234 ABC", Capacity = 20 },
                new Truck() { Id = 4, Color = "Gray", Model = "Nissan", Registration = "1234 ABC", Capacity = 20 },
                new Truck() { Id = 5, Color = "White", Model = "Nissan", Registration = "1234 ABC", Capacity = 20 }
            }.ToDictionary(c => c.Id));

        [HttpGet]
        public IEnumerable<Truck> Get()
        {
            return cars.Values;
        }

        [HttpGet("{id}")]
        public Truck Get(int id)
        {
            return cars[id];
        }

        [HttpPost]
        public void Post([FromBody]Truck value)
        {
            cars.AddOrUpdate(value.Id, value, (i, c) => c);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Truck value)
        {
            cars[id] = value;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cars.TryRemove(id, out Truck del);
        }
    }
}
