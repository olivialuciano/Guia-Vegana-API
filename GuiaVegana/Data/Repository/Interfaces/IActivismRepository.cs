using GuiaVegana.Models;

namespace GuiaVegana.Data.Repository.Interfaces
{
    public interface IActivismRepository
    {
        IEnumerable<ActivismDTO> GetAll();
        ActivismDTO GetById(int id);
        void Add(ActivismToCreateDTO activismToCreate);
        void Update(int id, ActivismToCreateDTO activismToUpdate);
        void Delete(int id);
    }
}
