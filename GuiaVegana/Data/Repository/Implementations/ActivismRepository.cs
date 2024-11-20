using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Entities;
using GuiaVegana.Models;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class ActivismRepository : IActivismRepository
    {
        private readonly GuiaVeganaContext _context;
        private readonly IMapper _mapper;

        public ActivismRepository(GuiaVeganaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Get all activism entities
        public IEnumerable<ActivismDTO> GetAll()
        {
            var activisms = _context.Activisms.ToList();
            return _mapper.Map<IEnumerable<ActivismDTO>>(activisms);
        }

        // GET: Get activism entity by ID
        public ActivismDTO GetById(int id)
        {
            var activism = _context.Activisms.FirstOrDefault(a => a.Id == id);
            return _mapper.Map<ActivismDTO>(activism);
        }

        // POST: Add a new activism entity
        public void Add(ActivismToCreateDTO activismToCreate)
        {
            var activism = _mapper.Map<Activism>(activismToCreate);
            _context.Activisms.Add(activism);
            _context.SaveChanges();
        }

        // PUT: Update an existing activism entity
        public void Update(int id, ActivismToCreateDTO activismToUpdate)
        {
            var existingActivism = _context.Activisms.FirstOrDefault(a => a.Id == id);
            if (existingActivism != null)
            {
                _mapper.Map(activismToUpdate, existingActivism);
                _context.SaveChanges();
            }
        }

        // DELETE: Remove an activism entity by ID
        public void Delete(int id)
        {
            var activism = _context.Activisms.FirstOrDefault(a => a.Id == id);
            if (activism != null)
            {
                _context.Activisms.Remove(activism);
                _context.SaveChanges();
            }
        }
    }
}
