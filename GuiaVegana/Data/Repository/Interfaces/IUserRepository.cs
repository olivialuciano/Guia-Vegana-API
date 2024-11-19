using GuiaVegana.Entities;
using GuiaVegana.Models;

namespace GuiaVegana.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        // GET
        User? GetById(int userId); // Obtener un usuario por ID
        List<User> GetAll(); // Obtener todos los usuarios
        List<User> GetAllActive(); // Obtener solo usuarios activos
        List<User> GetAllInactive(); // Obtener solo usuarios inactivos

        // POST (Sólo el Sysadmin puede crear un usuario)
        User AddUser(User user); // Agregar un nuevo usuario (solo Sysadmin)

        // PUT
        void UpdateUserData(User user); // Actualizar los datos de un usuario
        void UpdatePassword(int userId, string newPassword); // Cambiar la contraseña de un usuario

        // DELETE (Soft delete: desactivar usuarios)
        void DeactivateUser(int userId); // Desactivar un usuario (marcar como inactivo)
        void ReactivateUser(int userId); // Reactivar un usuario (marcar como activo)

    }
}
