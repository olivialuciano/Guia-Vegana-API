using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuiaVegana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivismController : ControllerBase
    {
        private readonly IActivismRepository _repository;

        public ActivismController(IActivismRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Activism
        [HttpGet]
        public ActionResult<IEnumerable<ActivismDTO>> GetAll()
        {
            var activisms = _repository.GetAll();
            return Ok(activisms);
        }

        // GET: api/Activism/{id}
        [HttpGet("{id}")]
        public ActionResult<ActivismDTO> GetById(int id)
        {
            var activism = _repository.GetById(id);
            if (activism == null)
                return NotFound();

            return Ok(activism);
        }

        // POST: api/Activism
        [HttpPost]
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult Add([FromBody] ActivismToCreateDTO activismToCreate)
        {
            _repository.Add(activismToCreate);
            return CreatedAtAction(nameof(GetById), new { id = activismToCreate }, activismToCreate);
        }

        // PUT: api/Activism/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult Update(int id, [FromBody] ActivismToCreateDTO activismToUpdate)
        {
            _repository.Update(id, activismToUpdate);
            return NoContent();
        }

        // DELETE: api/Activism/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
