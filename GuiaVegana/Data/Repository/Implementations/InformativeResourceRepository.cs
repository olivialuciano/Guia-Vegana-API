using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Entities;
using GuiaVegana.Models;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class InformativeResourceRepository : IInformativeResourceRepository
    {
        private readonly GuiaVeganaContext _context;

        public InformativeResourceRepository(GuiaVeganaContext context)
        {
            _context = context;
        }

        // GET: Get all informative resources
        public IEnumerable<InformativeResourceDTO> GetAll()
        {
            var resources = _context.InformativeResources.ToList();
            return resources.Select(r => new InformativeResourceDTO
            {
                Id = r.Id,
                Name = r.Name,
                Image = r.Image,
                Topic = r.Topic,
                Platform = r.Platform,
                Description = r.Description,
                Type = r.Type,
                UserId = r.UserId
            }).ToList();
        }

        // GET: Get informative resource by ID
        public InformativeResourceDTO GetById(int id)
        {
            var resource = _context.InformativeResources.FirstOrDefault(r => r.Id == id);
            if (resource == null) return null;

            return new InformativeResourceDTO
            {
                Id = resource.Id,
                Name = resource.Name,
                Image = resource.Image,
                Topic = resource.Topic,
                Platform = resource.Platform,
                Description = resource.Description,
                Type = resource.Type,
                UserId = resource.UserId
            };
        }

        // GET: Get informative resources by type
        public IEnumerable<InformativeResourceDTO> GetByType(ResourceType type)
        {
            var resources = _context.InformativeResources.Where(r => r.Type == type).ToList();
            return resources.Select(r => new InformativeResourceDTO
            {
                Id = r.Id,
                Name = r.Name,
                Image = r.Image,
                Topic = r.Topic,
                Platform = r.Platform,
                Description = r.Description,
                Type = r.Type,
                UserId = r.UserId
            }).ToList();
        }

        // POST: Add a new informative resource
        public void Add(InformativeResourceToCreateDTO informativeResourceToCreate)
        {
            var resource = new InformativeResource
            {
                Name = informativeResourceToCreate.Name,
                Image = informativeResourceToCreate.Image,
                Topic = informativeResourceToCreate.Topic,
                Platform = informativeResourceToCreate.Platform,
                Description = informativeResourceToCreate.Description,
                Type = informativeResourceToCreate.Type,
                UserId = informativeResourceToCreate.UserId
            };

            _context.InformativeResources.Add(resource);
            _context.SaveChanges();
        }

        // PUT: Update an existing informative resource
        public void Update(int id, InformativeResourceToCreateDTO informativeResourceToUpdate)
        {
            var existingResource = _context.InformativeResources.FirstOrDefault(r => r.Id == id);
            if (existingResource == null)
            {
                throw new KeyNotFoundException($"No se encontró un recurso informativo con ID {id}.");
            }

            existingResource.Name = informativeResourceToUpdate.Name;
            existingResource.Image = informativeResourceToUpdate.Image;
            existingResource.Topic = informativeResourceToUpdate.Topic;
            existingResource.Platform = informativeResourceToUpdate.Platform;
            existingResource.Description = informativeResourceToUpdate.Description;
            existingResource.Type = informativeResourceToUpdate.Type;
            existingResource.UserId = informativeResourceToUpdate.UserId;

            _context.SaveChanges();
        }

        // DELETE: Remove an informative resource by ID
        public void Delete(int id)
        {
            var resource = _context.InformativeResources.FirstOrDefault(r => r.Id == id);
            if (resource == null)
            {
                throw new KeyNotFoundException($"No se encontró un recurso informativo con ID {id}.");
            }

            _context.InformativeResources.Remove(resource);
            _context.SaveChanges();
        }
    }
}
