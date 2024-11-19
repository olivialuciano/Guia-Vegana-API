using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class BusinessRepository : IBusinessRepository
    {
        private GuiaVeganaContext _context;
        private readonly IMapper _mapper;
        public BusinessRepository(GuiaVeganaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // Métodos GET

        // 1. Traer todos los negocios
        public IEnumerable<Business> GetAllBusinesses()
        {
            return _context.Businesses.Include(b => b.OpeningHours).Include(b => b.VeganOptions).ToList();
        }

        // 2. Traer un negocio por ID
        public Business GetBusinessById(int id)
        {
            return _context.Businesses
                .Include(b => b.OpeningHours)
                .Include(b => b.VeganOptions)
                .FirstOrDefault(b => b.Id == id);
        }

        // 3. Filtrar por calificaciones
        public IEnumerable<Business> GetBusinessesByRatings(IEnumerable<Rating> ratings)
        {
            return _context.Businesses.Where(b => ratings.Contains(b.Rating)).ToList();
        }

        // 4. Filtrar por tipos de delivery
        public IEnumerable<Business> GetBusinessesByDeliveries(IEnumerable<DeliveryType> deliveries)
        {
            return _context.Businesses.Where(b => deliveries.Contains(b.Delivery)).ToList();
        }

        // 5. Filtrar por tipos de negocio
        public IEnumerable<Business> GetBusinessesByTypes(IEnumerable<BusinessType> businessTypes)
        {
            return _context.Businesses.Where(b => businessTypes.Contains(b.BusinessType)).ToList();
        }

        // 6. Filtrar por zonas
        public IEnumerable<Business> GetBusinessesByZones(IEnumerable<Zone> zones)
        {
            return _context.Businesses.Where(b => zones.Contains(b.Zone)).ToList();
        }

        // 7. Traer negocios totalmente basados en plantas
        public IEnumerable<Business> GetPlantBasedBusinesses()
        {
            return _context.Businesses.Where(b => b.AllPlantBased).ToList();
        }

        // 8. Traer negocios con opciones gluten-free
        public IEnumerable<Business> GetGlutenFreeBusinesses()
        {
            return _context.Businesses.Where(b => b.GlutenFree).ToList();
        }

        // 9. Traer negocios abiertos en el momento actual
        public IEnumerable<Business> GetBusinessesOpenAt(DateTime currentTime)
        {
            return _context.Businesses
                .Include(b => b.OpeningHours)
                .Where(b => b.OpeningHours.Any(oh =>
                    oh.DayOfWeek == currentTime.DayOfWeek &&
                    oh.OpenTime <= currentTime.TimeOfDay &&
                    oh.CloseTime >= currentTime.TimeOfDay))
                .ToList();
        }

        // Métodos POST

        // 10. Agregar un nuevo negocio
        public void AddBusiness(Business business)
        {
            _context.Businesses.Add(business);
            _context.SaveChanges();
        }

        // Métodos PUT

        // 11. Actualizar datos de un negocio existente
        public void UpdateBusiness(Business business)
        {
            _context.Businesses.Update(business);
            _context.SaveChanges();
        }

        // Métodos DELETE

        // 12. Eliminar un negocio por ID
        public void DeleteBusiness(int id)
        {
            var business = _context.Businesses.Find(id);
            if (business != null)
            {
                _context.Businesses.Remove(business);
                _context.SaveChanges();
            }
        }
    }
}
}
