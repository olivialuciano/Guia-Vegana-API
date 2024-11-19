using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Entities;
using GuiaVegana.Models;
using GuiaVegana.Repositories;
using System;

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

            // Métodos GET
            public User GetUserById(int id)
            {
                return _context.Users.FirstOrDefault(u => u.Id == id);
            }

            public IEnumerable<User> GetAllUsers()
            {
                return _context.Users.ToList();
            }

            public IEnumerable<User> GetActiveUsers()
            {
                return _context.Users.Where(u => u.IsActive).ToList();
            }

            public IEnumerable<User> GetInactiveUsers()
            {
                return _context.Users.Where(u => !u.IsActive).ToList();
            }

            // Métodos POST
            public void AddUser(User user)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            public User ValidateUser(string email, string password)
            {
                return _context.Users
                    .FirstOrDefault(u => u.Email == email && u.Password == password && u.IsActive);
            }

            // Métodos PUT
            public void UpdateUser(User user)
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);
                if (existingUser != null)
                {
                    existingUser.Name = user.Name;
                    existingUser.Email = user.Email;
                    existingUser.Role = user.Role;
                    _context.SaveChanges();
                }
            }

            public void UpdatePassword(int userId, string newPassword)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.Password = newPassword;
                    _context.SaveChanges();
                }
            }

            public void ActivateUser(int userId)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.IsActive = true;
                    _context.SaveChanges();
                }
            }

            public void InactivateUser(int userId)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.IsActive = false;
                    _context.SaveChanges();
                }
            }
        }
    }
