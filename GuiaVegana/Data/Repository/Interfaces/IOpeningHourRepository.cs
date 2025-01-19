using GuiaVegana.Models;

namespace GuiaVegana.Data.Repository.Interfaces
{
    public interface IOpeningHourRepository
    {
        IEnumerable<OpeningHourDTO> GetAll();
        IEnumerable<OpeningHourDTO> GetAllByBusinessId(int businessId);
        OpeningHourDTO GetById(int id);
        void Add(OpeningHourToCreateDTO openingHourToCreate);
        void Update(int id, OpeningHourToCreateDTO openingHourToUpdate);
        void Delete(int id);
    }
}
