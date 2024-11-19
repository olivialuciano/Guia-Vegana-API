using GuiaVegana.Entities;
using System.Collections.Generic;

namespace GuiaVegana.Repositories
{
    public interface IUserRepository
    {
        // Métodos GET
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> GetActiveUsers();
        IEnumerable<User> GetInactiveUsers();

        // Métodos POST
        void AddUser(User user);
        User ValidateUser(string email, string password);

        // Métodos PUT
        void UpdateUser(User user);
        void UpdatePassword(int userId, string newPassword);
        void ActivateUser(int userId);
        void InactivateUser(int userId);
    }
}
