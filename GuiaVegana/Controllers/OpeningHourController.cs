using Microsoft.AspNetCore.Mvc;
using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Models;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult GetAllOpeningHours()
        {
            var openingHours = _openingHourRepository.GetAll();
            return Ok(openingHours);
        }

        // GET: api/openinghour/business/{businessId}
        [HttpGet("business/{businessId}")]
        public IActionResult GetOpeningHoursByBusinessId(int businessId)
        {
            var openingHours = _openingHourRepository.GetAllByBusinessId(businessId);
            if (openingHours == null || !openingHours.Any())
            {
                return NotFound($"No opening hours found for business ID {businessId}.");
            }
            return Ok(openingHours);
        }

        // GET: api/openinghour/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "Sysadmin,Investigador")]
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
        [Authorize(Roles = "Sysadmin,Investigador")]
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
        [Authorize(Roles = "Sysadmin,Investigador")]
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
        [Authorize(Roles = "Sysadmin,Investigador")]
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
