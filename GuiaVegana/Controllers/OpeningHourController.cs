using Microsoft.AspNetCore.Mvc;
using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Models;

namespace GuiaVegana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpeningHourController : ControllerBase
    {
        private readonly IOpeningHourRepository _openingHourRepository;

        public OpeningHourController(IOpeningHourRepository openingHourRepository)
        {
            _openingHourRepository = openingHourRepository;
        }

        // GET: api/openinghour
        [HttpGet]
        public IActionResult GetAllOpeningHours()
        {
            var openingHours = _openingHourRepository.GetAll();
            return Ok(openingHours);
        }

        // GET: api/openinghour/{id}
        [HttpGet("{id}")]
        public IActionResult GetOpeningHourById(int id)
        {
            var openingHour = _openingHourRepository.GetById(id);
            if (openingHour == null)
            {
                return NotFound($"Opening hour with ID {id} was not found.");
            }
            return Ok(openingHour);
        }

        // POST: api/openinghour
        [HttpPost]
        public IActionResult AddOpeningHour([FromBody] OpeningHourToCreateDTO openingHourToCreate)
        {
            if (openingHourToCreate == null)
            {
                return BadRequest("Opening hour data is required.");
            }

            _openingHourRepository.Add(openingHourToCreate);
            return CreatedAtAction(nameof(GetOpeningHourById), new { id = openingHourToCreate.BusinessId }, openingHourToCreate);
        }

        // PUT: api/openinghour/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateOpeningHour(int id, [FromBody] OpeningHourToCreateDTO openingHourToUpdate)
        {
            if (openingHourToUpdate == null)
            {
                return BadRequest("Opening hour data is required.");
            }

            var existingOpeningHour = _openingHourRepository.GetById(id);
            if (existingOpeningHour == null)
            {
                return NotFound($"Opening hour with ID {id} was not found.");
            }

            _openingHourRepository.Update(id, openingHourToUpdate);
            return NoContent();
        }

        // DELETE: api/openinghour/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteOpeningHour(int id)
        {
            var existingOpeningHour = _openingHourRepository.GetById(id);
            if (existingOpeningHour == null)
            {
                return NotFound($"Opening hour with ID {id} was not found.");
            }

            _openingHourRepository.Delete(id);
            return NoContent();
        }
    }
}
