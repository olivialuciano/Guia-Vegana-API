using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Entities;
using GuiaVegana.Models;
using Microsoft.EntityFrameworkCore;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class VeganOptionRepository : IVeganOptionRepository
    {
        private readonly GuiaVeganaContext _context;

        public VeganOptionRepository(GuiaVeganaContext context)
        {
            _context = context;
        }

        // GET: Get all vegan options
        public IEnumerable<VeganOption> GetAll()
        {
            return _context.VeganOptions.ToList();
        }


        // GET: Get all vegan options for a specific business
        public IEnumerable<VeganOption> GetAllByBusinessId(int businessId)
        {
            return _context.VeganOptions.Where(vo => vo.BusinessId == businessId).ToList();
        }


        // GET: Get a vegan option by ID
        public VeganOption GetById(int id)
        {
            return _context.VeganOptions.FirstOrDefault(vo => vo.Id == id);
        }


        // POST: Add a new vegan option
        public void Add(VeganOptionToCreateDTO veganOptionToCreate)
        {
            if (veganOptionToCreate == null)
                throw new ArgumentNullException(nameof(veganOptionToCreate));

            var veganOption = new VeganOption
            {
                Name = veganOptionToCreate.Name,           
                Price = veganOptionToCreate.Price,         
                BusinessId = veganOptionToCreate.BusinessId 
            };

            _context.VeganOptions.Add(veganOption);
            _context.SaveChanges();
        }


        // PUT: Update an existing vegan option
        public void Update(int id, VeganOptionToCreateDTO veganOptionToUpdate)
        {
            if (veganOptionToUpdate == null)
                throw new ArgumentNullException(nameof(veganOptionToUpdate));

            var existingOption = _context.VeganOptions.FirstOrDefault(vo => vo.Id == id);
            if (existingOption == null)
                throw new KeyNotFoundException($"Vegan option with ID {id} was not found.");

            existingOption.Name = veganOptionToUpdate.Name;   
            existingOption.Price = veganOptionToUpdate.Price;    
            existingOption.BusinessId = veganOptionToUpdate.BusinessId; 

            _context.SaveChanges();
        }


        // DELETE: Remove a vegan option by ID
        public void Delete(int id)
        {
            var veganOption = _context.VeganOptions.FirstOrDefault(vo => vo.Id == id);
            if (veganOption == null)
                throw new KeyNotFoundException($"Vegan option with ID {id} was not found.");

            _context.VeganOptions.Remove(veganOption);
            _context.SaveChanges();
        }
    }
}
