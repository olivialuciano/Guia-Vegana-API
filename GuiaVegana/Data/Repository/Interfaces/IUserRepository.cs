using GuiaVegana.Entities;
using GuiaVegana.Models;
using System.Collections.Generic;

namespace GuiaVegana.Repositories.Interfaces
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
        User ValidateUser(AuthenticationRequestBody authRequestBody);

        // Métodos PUT
        void UpdateUser(User user);
        void UpdatePassword(int userId, string newPassword);
        void ActivateUser(int userId);
        void InactivateUser(int userId);
    }
}
