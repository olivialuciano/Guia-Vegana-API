using Microsoft.AspNetCore.Mvc;
using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Models;

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
        public IActionResult GetAllVeganOptions()
        {
            var veganOptions = _veganOptionRepository.GetAll();
            return Ok(veganOptions);
        }

        // GET: api/veganoption/{id}
        [HttpGet("{id}")]
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
