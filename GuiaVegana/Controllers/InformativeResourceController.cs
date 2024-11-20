using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuiaVegana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformativeResourceController : ControllerBase
    {
        private readonly IInformativeResourceRepository _repository;

        public InformativeResourceController(IInformativeResourceRepository repository)
        {
            _repository = repository;
        }

        // GET: api/InformativeResource
        [HttpGet]
        public ActionResult<IEnumerable<InformativeResourceDTO>> GetAll()
        {
            var resources = _repository.GetAll();
            return Ok(resources);
        }

        // GET: api/InformativeResource/{id}
        [HttpGet("{id}")]
        public ActionResult<InformativeResourceDTO> GetById(int id)
        {
            var resource = _repository.GetById(id);
            if (resource == null)
                return NotFound();

            return Ok(resource);
        }

        // GET: api/InformativeResource/type/{type}
        [HttpGet("type/{type}")]
        public ActionResult<IEnumerable<InformativeResourceDTO>> GetByType(ResourceType type)
        {
            var resources = _repository.GetByType(type);
            return Ok(resources);
        }

        // POST: api/InformativeResource
        [HttpPost]
        public IActionResult Add([FromBody] InformativeResourceToCreateDTO resourceToCreate)
        {
            _repository.Add(resourceToCreate);
            return CreatedAtAction(nameof(GetById), new { id = resourceToCreate }, resourceToCreate);
        }

        // PUT: api/InformativeResource/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] InformativeResourceToCreateDTO resourceToUpdate)
        {
            _repository.Update(id, resourceToUpdate);
            return NoContent();
        }

        // DELETE: api/InformativeResource/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
