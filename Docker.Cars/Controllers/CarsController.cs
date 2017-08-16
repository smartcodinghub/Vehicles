using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Docker.Cars.Model;

namespace Docker.Cars.Controllers
{
    [Route("vehicles/[controller]")]
    public class CarsController : Controller
    {
        private static readonly ConcurrentDictionary<int, Car> cars = new ConcurrentDictionary<int, Car>(
            new Car[]
            {
                new Car() { Id = 1, Color = "Green",Model = "Nissan",Registration = "1234 ABC"},
                new Car() { Id = 2, Color = "Red",Model = "Nissan",Registration = "1234 ABC"},
                new Car() { Id = 3, Color = "Blue",Model = "Nissan",Registration = "1234 ABC"},
                new Car() { Id = 4, Color = "Gray",Model = "Nissan",Registration = "1234 ABC"},
                new Car() { Id = 5, Color = "White",Model = "Nissan",Registration = "1234 ABC"}
            }.ToDictionary(c => c.Id));

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return cars.Values;
        }

        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return cars[id];
        }

        [HttpPost]
        public void Post([FromBody]Car value)
        {
            cars.AddOrUpdate(value.Id, value, (i, c) => c);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Car value)
        {
            cars[id] = value;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cars.TryRemove(id, out Car del);
        }
    }
}
