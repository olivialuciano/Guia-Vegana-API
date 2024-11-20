using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Entities;
using GuiaVegana.Models;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class OpeningHourRepository : IOpeningHourRepository
    {
        private GuiaVeganaContext _context;
        private readonly IMapper _mapper;

        public OpeningHourRepository(GuiaVeganaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Get all opening hours
        public IEnumerable<OpeningHourDTO> GetAll()
        {
            var openingHours = _context.OpeningHours.ToList();
            return _mapper.Map<IEnumerable<OpeningHourDTO>>(openingHours);
        }

        // GET: Get opening hour by ID
        public OpeningHourDTO GetById(int id)
        {
            var openingHour = _context.OpeningHours.FirstOrDefault(oh => oh.Id == id);
            return openingHour != null ? _mapper.Map<OpeningHourDTO>(openingHour) : null;
        }

        // POST: Add a new opening hour
        public void Add(OpeningHourToCreateDTO openingHourToCreate)
        {
            var openingHour = _mapper.Map<OpeningHour>(openingHourToCreate);
            _context.OpeningHours.Add(openingHour);
            _context.SaveChanges();
        }

        // PUT: Update an existing opening hour
        public void Update(int id, OpeningHourToCreateDTO openingHourToUpdate)
        {
            var existingOpeningHour = _context.OpeningHours.FirstOrDefault(oh => oh.Id == id);
            if (existingOpeningHour != null)
            {
                _mapper.Map(openingHourToUpdate, existingOpeningHour);
                _context.SaveChanges();
            }
        }

        // DELETE: Remove an opening hour by ID
        public void Delete(int id)
        {
            var openingHour = _context.OpeningHours.FirstOrDefault(oh => oh.Id == id);
            if (openingHour != null)
            {
                _context.OpeningHours.Remove(openingHour);
                _context.SaveChanges();
            }
        }
    }
}
