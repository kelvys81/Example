using Microsoft.AspNetCore.Mvc;
using WebAPI.Filters.ActionFilters;
using WebAPI.Models;
using WebAPI.Models.Repositories;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController: ControllerBase
    {

        [HttpGet]
        public IActionResult GetCars() 
        {
            return Ok(CarRepository.GetCars());
        }

        [HttpGet("{id}")]
        [Car_ValidateCarIdFilter]
        public IActionResult GetCarById(int id)
        {
            return Ok(CarRepository.GetCarById(id));
        }

        [HttpPost]
        [Car_ValidateCreateCarFilter]
        public IActionResult CreateCars([FromBody]Car car)
        {
            CarRepository.AddCar(car);
            return CreatedAtAction(nameof(GetCarById),new {id = car.CartId}, car);
        }

        [HttpPatch("{id}")]
        [Car_ValidateCarIdFilter]
        [Car_ValidateUpdateCarFilter]
        public IActionResult UpdateCar(int id, Car car)
        {
            CarRepository.UpdateCar(car);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Car_ValidateCarIdFilter]
        public IActionResult DeleteCar(int id)
        {
            var car = CarRepository.GetCarById(id);
            CarRepository.DeleteCar(id);
            return Ok(car);
        }
    }
}
