using GuiaVegana.Entities;

namespace GuiaVegana.Data.Repository.Interfaces
{
    public class IBusinessRepository
    {
        // Métodos GET
        IEnumerable<Business> GetAllBusinesses();
        Business GetBusinessById(int id);
        IEnumerable<Business> GetBusinessesByRatings(IEnumerable<Rating> ratings);
        IEnumerable<Business> GetBusinessesByDeliveries(IEnumerable<DeliveryType> deliveries);
        IEnumerable<Business> GetBusinessesByTypes(IEnumerable<BusinessType> businessTypes);
        IEnumerable<Business> GetBusinessesByZones(IEnumerable<Zone> zones);
        IEnumerable<Business> GetPlantBasedBusinesses();
        IEnumerable<Business> GetGlutenFreeBusinesses();
        IEnumerable<Business> GetBusinessesOpenAt(DateTime currentTime);

        // Métodos POST
        void AddBusiness(Business business);

        // Métodos PUT
        void UpdateBusiness(Business business);

        // Métodos DELETE
        void DeleteBusiness(int id);
    }
}
