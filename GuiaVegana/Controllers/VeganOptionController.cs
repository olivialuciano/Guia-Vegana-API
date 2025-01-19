using Microsoft.AspNetCore.Mvc;
using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Models;
using Microsoft.AspNetCore.Authorization;
using GuiaVegana.Entities;

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
            try
            {
                var veganOptions = _veganOptionRepository.GetAll();
                return Ok(veganOptions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/veganoption/business/{businessId}
        [HttpGet("business/{businessId}")]
        public IActionResult GetVeganOptionsByBusinessId(int businessId)
        {
            try
            {
                var veganOptions = _veganOptionRepository.GetAllByBusinessId(businessId);
                if (veganOptions == null || !veganOptions.Any())
                {
                    return NotFound($"No vegan options found for business ID {businessId}.");
                }
                return Ok(veganOptions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/veganoption/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult GetVeganOptionById(int id)
        {
            try
            {
                var veganOption = _veganOptionRepository.GetById(id);
                if (veganOption == null)
                {
                    return NotFound($"Vegan option with ID {id} was not found.");
                }
                return Ok(veganOption);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
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

            try
            {
                _veganOptionRepository.Add(veganOptionToCreate);
                return Ok(veganOptionToCreate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
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

            try
            {
                _veganOptionRepository.Update(id, veganOptionToUpdate);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/veganoption/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult DeleteVeganOption(int id)
        {
            try
            {
                _veganOptionRepository.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
