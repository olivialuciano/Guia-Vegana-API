using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Entities;
using GuiaVegana.Models;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class VeganOptionRepository : IVeganOptionRepository
    {
        private GuiaVeganaContext _context;
        private readonly IMapper _mapper;
        public VeganOptionRepository(GuiaVeganaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET //
        // Get all vegan options
        public IEnumerable<VeganOption> GetAll()
        {
            return _context.VeganOptions.ToList();
        }

        // GET: Get all vegan options for a specific business
        public IEnumerable<VeganOption> GetAllByBusinessId(int businessId)
        {
            return _context.VeganOptions.Where(vo => vo.BusinessId == businessId).ToList();
        }

        // Get a vegan option by ID
        public VeganOption GetById(int id)
        {
            return _context.VeganOptions.FirstOrDefault(vo => vo.Id == id);
        }

        // POST: Add a new vegan option
        public void Add(VeganOptionToCreateDTO veganOptionToCreate)
        {
            var veganOption = _mapper.Map<VeganOption>(veganOptionToCreate);
            _context.VeganOptions.Add(veganOption);
            _context.SaveChanges();
        }

        // PUT: Update an existing vegan option
        public void Update(int id, VeganOptionToCreateDTO veganOptionToUpdate)
        {
            var existingOption = _context.VeganOptions.FirstOrDefault(vo => vo.Id == id);
            if (existingOption != null)
            {
                _mapper.Map(veganOptionToUpdate, existingOption);
                _context.SaveChanges();
            }
        }

        // DELETE: Remove a vegan option by ID
        public void Delete(int id)
        {
            var veganOption = _context.VeganOptions.FirstOrDefault(vo => vo.Id == id);
            if (veganOption != null)
            {
                _context.VeganOptions.Remove(veganOption);
                _context.SaveChanges();
            }
        }
    }
}

