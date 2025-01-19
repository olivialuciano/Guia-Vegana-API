using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Entities;
using GuiaVegana.Models;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class OpeningHourRepository : IOpeningHourRepository
    {
        private GuiaVeganaContext _context;

        public OpeningHourRepository(GuiaVeganaContext context)
        {
            _context = context;
        }

        // GET: Get all opening hours
        public IEnumerable<OpeningHourDTO> GetAll()
        {
            var openingHours = _context.OpeningHours.ToList();
            return openingHours.Select(oh => new OpeningHourDTO
            {
                Id = oh.Id,
                Day = oh.Day,
                OpenTime1 = oh.OpenTime1,
                CloseTime1 = oh.CloseTime1,
                OpenTime2 = oh.OpenTime2,
                CloseTime2 = oh.CloseTime2,
                BusinessId = oh.BusinessId
            });
        }

        // GET: Get all opening hours for a specific business
        public IEnumerable<OpeningHourDTO> GetAllByBusinessId(int businessId)
        {
            var openingHours = _context.OpeningHours.Where(oh => oh.BusinessId == businessId).ToList();
            return openingHours.Select(oh => new OpeningHourDTO
            {
                Id = oh.Id,
                Day = oh.Day,
                OpenTime1 = oh.OpenTime1,
                CloseTime1 = oh.CloseTime1,
                OpenTime2 = oh.OpenTime2,
                CloseTime2 = oh.CloseTime2,
                BusinessId = oh.BusinessId
            });
        }

        // GET: Get opening hour by ID
        public OpeningHourDTO GetById(int id)
        {
            var openingHour = _context.OpeningHours.FirstOrDefault(oh => oh.Id == id);
            if (openingHour == null)
            {
                return null;
            }

            return new OpeningHourDTO
            {
                Id = openingHour.Id,
                Day = openingHour.Day,
                OpenTime1 = openingHour.OpenTime1,
                CloseTime1 = openingHour.CloseTime1,
                OpenTime2 = openingHour.OpenTime2,
                CloseTime2 = openingHour.CloseTime2,
                BusinessId = openingHour.BusinessId
            };
        }

        // POST: Add a new opening hour
        public void Add(OpeningHourToCreateDTO openingHourToCreate)
        {
            if (openingHourToCreate.OpenTime1 >= openingHourToCreate.CloseTime1)
            {
                throw new ArgumentException("OpenTime1 debe ser menor que CloseTime1.");
            }
            if (openingHourToCreate.OpenTime2.HasValue && openingHourToCreate.CloseTime2.HasValue)
            {
                if (openingHourToCreate.OpenTime2 >= openingHourToCreate.CloseTime2)
                {
                    throw new ArgumentException("OpenTime2 debe ser menor que CloseTime2.");
                }
            }

            var openingHour = new OpeningHour
            {
                Day = openingHourToCreate.Day,
                OpenTime1 = openingHourToCreate.OpenTime1,
                CloseTime1 = openingHourToCreate.CloseTime1,
                OpenTime2 = openingHourToCreate.OpenTime2,
                CloseTime2 = openingHourToCreate.CloseTime2,
                BusinessId = openingHourToCreate.BusinessId
            };

            _context.OpeningHours.Add(openingHour);
            _context.SaveChanges();
        }

        // PUT: Update an existing opening hour
        public void Update(int id, OpeningHourToCreateDTO openingHourToUpdate)
        {
            var existingOpeningHour = _context.OpeningHours.FirstOrDefault(oh => oh.Id == id);
            if (existingOpeningHour == null)
            {
                throw new KeyNotFoundException($"No se encontró un horario de apertura con ID {id}.");
            }

            if (openingHourToUpdate.OpenTime1 >= openingHourToUpdate.CloseTime1)
            {
                throw new ArgumentException("OpenTime1 debe ser menor que CloseTime1.");
            }
            if (openingHourToUpdate.OpenTime2.HasValue && openingHourToUpdate.CloseTime2.HasValue)
            {
                if (openingHourToUpdate.OpenTime2 >= openingHourToUpdate.CloseTime2)
                {
                    throw new ArgumentException("OpenTime2 debe ser menor que CloseTime2.");
                }
            }

            existingOpeningHour.Day = openingHourToUpdate.Day;
            existingOpeningHour.OpenTime1 = openingHourToUpdate.OpenTime1;
            existingOpeningHour.CloseTime1 = openingHourToUpdate.CloseTime1;
            existingOpeningHour.OpenTime2 = openingHourToUpdate.OpenTime2;
            existingOpeningHour.CloseTime2 = openingHourToUpdate.CloseTime2;
            existingOpeningHour.BusinessId = openingHourToUpdate.BusinessId;

            _context.SaveChanges();
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
