using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using OblOpg4.Managers;

namespace OblOpg4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private CarManager _carManager = new CarManager();
        // GET: CarController

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get([FromQuery] string filterString, [FromQuery] int? priceFilter)
        {
            IEnumerable<Car> cars = null;

            cars = _carManager.GetAll(filterString, priceFilter);
            if (cars.Count()==0)
            {
                return NotFound("No cars found");
            }

            return Ok(cars);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            Car car = _carManager.GetById(id);

            if (car==null)
            {
                return NotFound("No car with id: " + id+" found");
            }

            return Ok(car);
        }
        // POST: CarController/Create
        [HttpPost]
        public bool Post([FromBody] Car value)
        {
            return _carManager.AddCar(value);
        }



        // GET: CarController/Delete/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            Car car = _carManager.GetById(id);
            if (car == null)
            {
                return NotFound("No car with id: " + id + " found");
            }
            
            _carManager.DeleteCar(id);
            return Ok(car);
        }



    }
}
