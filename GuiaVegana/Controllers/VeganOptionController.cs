using Microsoft.AspNetCore.Mvc;
using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Models;
using Microsoft.AspNetCore.Authorization;

namespace GuiaVegana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeganOptionController : ControllerBase
    {
        private readonly IVeganOptionRepository _veganOptionRepository;

        public VeganOptionController(IVeganOptionRepository veganOptionRepository)
        {
            _veganOptionRepository = veganOptionRepository;
        }

        // GET: api/veganoption
        [HttpGet]
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult GetAllVeganOptions()
        {
            var veganOptions = _veganOptionRepository.GetAll();
            return Ok(veganOptions);
        }

        // GET: api/veganoption/business/{businessId}
        [HttpGet("business/{businessId}")]
        public IActionResult GetVeganOptionsByBusinessId(int businessId)
        {
            var veganOptions = _veganOptionRepository.GetAllByBusinessId(businessId);
            if (veganOptions == null || !veganOptions.Any())
            {
                return NotFound($"No vegan options found for business ID {businessId}.");
            }
            return Ok(veganOptions);
        }


        // GET: api/veganoption/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult GetVeganOptionById(int id)
        {
            var veganOption = _veganOptionRepository.GetById(id);
            if (veganOption == null)
            {
                return NotFound($"Vegan option with ID {id} was not found.");
            }
            return Ok(veganOption);
        }

        // POST: api/veganoption
        [HttpPost]
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult AddVeganOption([FromBody] VeganOptionToCreateDTO veganOptionToCreate)
        {
            if (veganOptionToCreate == null)
            {
                return BadRequest("Vegan option data is required.");
            }

            _veganOptionRepository.Add(veganOptionToCreate);
            return CreatedAtAction(nameof(GetVeganOptionById), new { id = veganOptionToCreate.BusinessId }, veganOptionToCreate);
        }

        // PUT: api/veganoption/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult UpdateVeganOption(int id, [FromBody] VeganOptionToCreateDTO veganOptionToUpdate)
        {
            if (veganOptionToUpdate == null)
            {
                return BadRequest("Vegan option data is required.");
            }

            var existingOption = _veganOptionRepository.GetById(id);
            if (existingOption == null)
            {
                return NotFound($"Vegan option with ID {id} was not found.");
            }

            _veganOptionRepository.Update(id, veganOptionToUpdate);
            return NoContent();
        }

        // DELETE: api/veganoption/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult DeleteVeganOption(int id)
        {
            var existingOption = _veganOptionRepository.GetById(id);
            if (existingOption == null)
            {
                return NotFound($"Vegan option with ID {id} was not found.");
            }

            _veganOptionRepository.Delete(id);
            return NoContent();
        }
    }
}
