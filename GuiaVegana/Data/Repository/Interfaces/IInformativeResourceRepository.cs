using GuiaVegana.Models;

namespace GuiaVegana.Data.Repository.Interfaces
{
    public interface IInformativeResourceRepository
    {
        IEnumerable<InformativeResourceDTO> GetAll();
        InformativeResourceDTO GetById(int id);
        IEnumerable<InformativeResourceDTO> GetByType(ResourceType type);
        void Add(InformativeResourceToCreateDTO informativeResourceToCreate);
        void Update(int id, InformativeResourceToCreateDTO informativeResourceToUpdate);
        void Delete(int id);
    }
}
