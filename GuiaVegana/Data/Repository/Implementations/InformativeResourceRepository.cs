using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Entities;
using GuiaVegana.Models;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class InformativeResourceRepository : IInformativeResourceRepository
    {
        private readonly GuiaVeganaContext _context;
        private readonly IMapper _mapper;

        public InformativeResourceRepository(GuiaVeganaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Get all informative resources
        public IEnumerable<InformativeResourceDTO> GetAll()
        {
            var resources = _context.InformativeResources.ToList();
            return _mapper.Map<IEnumerable<InformativeResourceDTO>>(resources);
        }

        // GET: Get informative resource by ID
        public InformativeResourceDTO GetById(int id)
        {
            var resource = _context.InformativeResources.FirstOrDefault(r => r.Id == id);
            return _mapper.Map<InformativeResourceDTO>(resource);
        }

        // GET: Get informative resources by type
        public IEnumerable<InformativeResourceDTO> GetByType(ResourceType type) // Nuevo método
        {
            var resources = _context.InformativeResources.Where(r => r.Type == type).ToList();
            return _mapper.Map<IEnumerable<InformativeResourceDTO>>(resources);
        }

        // POST: Add a new informative resource
        public void Add(InformativeResourceToCreateDTO informativeResourceToCreate)
        {
            var resource = _mapper.Map<InformativeResource>(informativeResourceToCreate);
            _context.InformativeResources.Add(resource);
            _context.SaveChanges();
        }

        // PUT: Update an existing informative resource
        public void Update(int id, InformativeResourceToCreateDTO informativeResourceToUpdate)
        {
            var existingResource = _context.InformativeResources.FirstOrDefault(r => r.Id == id);
            if (existingResource != null)
            {
                _mapper.Map(informativeResourceToUpdate, existingResource);
                _context.SaveChanges();
            }
        }

        // DELETE: Remove an informative resource by ID
        public void Delete(int id)
        {
            var resource = _context.InformativeResources.FirstOrDefault(r => r.Id == id);
            if (resource != null)
            {
                _context.InformativeResources.Remove(resource);
                _context.SaveChanges();
            }
        }
    }
}
