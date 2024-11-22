using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Entities;
using GuiaVegana.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuiaVegana.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessRepository _businessRepository;

        public BusinessController(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }

        // GET: api/Business
        [HttpGet]
        public IActionResult GetAllBusinesses()
        {
            var businesses = _businessRepository.GetAllBusinesses();
            return Ok(businesses); // Ya viene mapeado desde el repositorio
        }

        // GET: api/Business/{id}
        [HttpGet("{id}")]
        public IActionResult GetBusinessById(int id)
        {
            var business = _businessRepository.GetBusinessById(id);
            if (business == null)
            {
                return NotFound(new { Message = "Business not found." });
            }
            return Ok(business); // Ya viene mapeado desde el repositorio
        }

        // POST: api/Business
        [HttpPost]
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult CreateBusiness([FromBody] BusinessToCreateDTO businessToCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid business data." });
            }

            _businessRepository.AddBusiness(businessToCreateDto); // El mapeo ya se hace en el repositorio

            return Ok();
        }

        // PUT: api/Business
        [HttpPut]
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult UpdateBusiness([FromBody] BusinessDTO businessDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid business data." });
            }

            _businessRepository.UpdateBusiness(businessDto); // El mapeo ya se hace en el repositorio

            return NoContent();
        }

        // DELETE: api/Business/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult DeleteBusiness(int id)
        {
            var business = _businessRepository.GetBusinessById(id);
            if (business == null)
            {
                return NotFound(new { Message = "Business not found." });
            }

            _businessRepository.DeleteBusiness(id);
            return NoContent();
        }
    }
}
