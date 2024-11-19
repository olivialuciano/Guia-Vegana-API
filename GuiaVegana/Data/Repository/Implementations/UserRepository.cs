using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Entities;
using GuiaVegana.Models;

namespace GuiaVegana.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private GuiaVeganaContext _context;
        private readonly IMapper _mapper;
        public UserRepository(GuiaVeganaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //////// GET ////////

        // Obtener un usuario por su ID
        public User? GetById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }

        // Obtener todos los usuarios (sin filtro de IsActive)
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        // Obtener todos los usuarios activos
        public List<User> GetAllActive()
        {
            return _context.Users.Where(u => u.IsActive).ToList();
        }

        // Obtener todos los usuarios inactivos
        public List<User> GetAllInactive()
        {
            return _context.Users.Where(u => !u.IsActive).ToList();
        }

        //////// POST ////////

        // Validar las credenciales de un usuario durante el login
        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users
                .FirstOrDefault(p => p.Email == authRequestBody.Email && p.Password == authRequestBody.Password);
        }

        // Crear un nuevo usuario
        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        // Crear un nuevo usuario con la inclusión de una lista de negocios, si es necesario
        public User AddUserWithBusinesses(User user, List<Business> businesses)
        {
            _context.Users.Add(user);
            _context.Businesses.AddRange(businesses);
            _context.SaveChanges();
            return user;
        }

        //////// PUT ////////

        // Actualizar los datos del usuario (puede incluir actualización de contraseñas, nombre, rol, etc.)
        public void UpdateUserData(User user)
        {
            var userItem = _context.Users.FirstOrDefault(u => u.Id == user.Id);

            if (userItem != null)
            {
                userItem.Name = user.Name;
                userItem.Email = user.Email;
                userItem.Password = user.Password;
                userItem.Role = user.Role;
                userItem.IsActive = user.IsActive; // Se permite modificar el estado de IsActive
                userItem.Image = user.Image;

                _context.SaveChanges();
            }
        }

        // Cambiar la contraseña de un usuario
        public void UpdatePassword(int userId, string newPassword)
        {
            var userItem = _context.Users.SingleOrDefault(u => u.Id == userId);

            if (userItem != null)
            {
                userItem.Password = newPassword;
                _context.SaveChanges();
            }
        }

        // Desactivar un usuario (en lugar de eliminarlo)
        public void DeactivateUser(int userId)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                user.IsActive = false;
                _context.SaveChanges();
            }
        }

        // Reactivar un usuario previamente desactivado
        public void ReactivateUser(int userId)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null && !user.IsActive)
            {
                user.IsActive = true;
                _context.SaveChanges();
            }
        }
    }
}
