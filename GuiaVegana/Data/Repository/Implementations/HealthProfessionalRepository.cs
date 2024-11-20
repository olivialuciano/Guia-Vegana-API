using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Entities;
using GuiaVegana.Models;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class HealthProfessionalRepository : IHealthProfessionalRepository
    {
        private readonly GuiaVeganaContext _context;
        private readonly IMapper _mapper;

        public HealthProfessionalRepository(GuiaVeganaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Get all health professionals
        public IEnumerable<HealthProfessionalDTO> GetAll()
        {
            var professionals = _context.HealthProfessionals.ToList();
            return _mapper.Map<IEnumerable<HealthProfessionalDTO>>(professionals);
        }

        // GET: Get health professional by ID
        public HealthProfessionalDTO GetById(int id)
        {
            var professional = _context.HealthProfessionals.FirstOrDefault(p => p.Id == id);
            return _mapper.Map<HealthProfessionalDTO>(professional);
        }

        // POST: Add a new health professional
        public void Add(HealthProfessionalToCreateDTO healthProfessionalToCreate)
        {
            var professional = _mapper.Map<HealthProfessional>(healthProfessionalToCreate);
            _context.HealthProfessionals.Add(professional);
            _context.SaveChanges();
        }

        // PUT: Update an existing health professional
        public void Update(int id, HealthProfessionalToCreateDTO healthProfessionalToUpdate)
        {
            var existingProfessional = _context.HealthProfessionals.FirstOrDefault(p => p.Id == id);
            if (existingProfessional != null)
            {
                _mapper.Map(healthProfessionalToUpdate, existingProfessional);
                _context.SaveChanges();
            }
        }

        // DELETE: Remove a health professional by ID
        public void Delete(int id)
        {
            var professional = _context.HealthProfessionals.FirstOrDefault(p => p.Id == id);
            if (professional != null)
            {
                _context.HealthProfessionals.Remove(professional);
                _context.SaveChanges();
            }
        }
    }
}
