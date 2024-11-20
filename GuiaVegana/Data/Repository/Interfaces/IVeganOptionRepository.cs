using GuiaVegana.Entities;
using GuiaVegana.Models;

namespace GuiaVegana.Data.Repository.Interfaces
{
    public interface IVeganOptionRepository
    {
        IEnumerable<VeganOption> GetAll();
        VeganOption GetById(int id);
        void Add(VeganOptionToCreateDTO veganOptionToCreate);
        void Update(int id, VeganOptionToCreateDTO veganOptionToUpdate);
        void Delete(int id);

    }
}
