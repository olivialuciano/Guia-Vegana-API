using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuiaVegana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthProfessionalController : ControllerBase
    {
        private readonly IHealthProfessionalRepository _repository;

        public HealthProfessionalController(IHealthProfessionalRepository repository)
        {
            _repository = repository;
        }

        // GET: api/HealthProfessional
        [HttpGet]
        public ActionResult<IEnumerable<HealthProfessionalDTO>> GetAll()
        {
            var professionals = _repository.GetAll();
            return Ok(professionals);
        }

        // GET: api/HealthProfessional/{id}
        [HttpGet("{id}")]
        public ActionResult<HealthProfessionalDTO> GetById(int id)
        {
            var professional = _repository.GetById(id);
            if (professional == null)
                return NotFound();

            return Ok(professional);
        }

        // POST: api/HealthProfessional
        [HttpPost]
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult Add([FromBody] HealthProfessionalToCreateDTO professionalToCreate)
        {
            _repository.Add(professionalToCreate);
            return CreatedAtAction(nameof(GetById), new { id = professionalToCreate }, professionalToCreate);
        }

        // PUT: api/HealthProfessional/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult Update(int id, [FromBody] HealthProfessionalToCreateDTO professionalToUpdate)
        {
            _repository.Update(id, professionalToUpdate);
            return NoContent();
        }

        // DELETE: api/HealthProfessional/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
