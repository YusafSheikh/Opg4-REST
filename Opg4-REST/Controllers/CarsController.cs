using Microsoft.AspNetCore.Mvc;
using Opg4_REST.Repository;
using ObliOpgave;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Opg4_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private CarRepository _carRepository;
        public CarsController(CarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        // GET: api/<CarController>
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAll()
        {
            List<Car> allCars = _carRepository.GetAll();
            if (allCars.Count < 1)
            {
                return NoContent(); // NotFound kan også bruges
            }

            Response.Headers.Add("TotalAmount", "" + allCars.Count());

            return Ok(allCars);
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CarController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Car> Post(Car newCar)
        {
            try
            {
                Car CreatedCar = _carRepository.Add(newCar);
                return Created($"api/cars/{CreatedCar.Id}", newCar);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex) // skal slutte med argument exception
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public ActionResult<Car> Put(int id, [FromBody] Car updates)
        {
            try
            {
                Car? foundCars = _carRepository.Update(id, updates);
                if (foundCars == null)
                {
                    return NotFound();
                }
                return Ok(foundCars);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex) // skal slutte med argument exception
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CarController>/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            Car DeletedCar = _carRepository.Delete(id);
            if (DeletedCar == null)
            {
                return NotFound();
            }
            return NoContent();

        }
    }
}