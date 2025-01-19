using GuiaVegana.Models;

namespace GuiaVegana.Data.Repository.Interfaces
{
    public interface IHealthProfessionalRepository
    {
        IEnumerable<HealthProfessionalDTO> GetAll();
        HealthProfessionalDTO GetById(int id);
        void Add(HealthProfessionalToCreateDTO healthProfessionalToCreate);
        void Update(int id, HealthProfessionalToCreateDTO healthProfessionalToUpdate);
        void Delete(int id);
    }
}
