using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Entities;
using GuiaVegana.Models;
using GuiaVegana.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GuiaVegana.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public UserController(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "Sysadmin")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound(new { Message = "User not found." });
            }

            // Mapeo manual del usuario
            var userDto = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                IsActive = user.IsActive,
                Role = user.Role
            };

            return Ok(userDto);
        }

        // GET: api/User
        [HttpGet]
        [Authorize(Roles = "Sysadmin")]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();

            // Mapeo manual de todos los usuarios
            var userDtos = users.Select(user => new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                IsActive = user.IsActive,
                Role = user.Role
            }).ToList();

            return Ok(userDtos);
        }

        // GET: api/User/active
        [HttpGet("active")]
        [Authorize(Roles = "Sysadmin")]
        public IActionResult GetActiveUsers()
        {
            var users = _userRepository.GetActiveUsers();

            // Mapeo manual de usuarios activos
            var userDtos = users.Select(user => new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                IsActive = user.IsActive,
                Role = user.Role
            }).ToList();

            return Ok(userDtos);
        }

        // GET: api/User/inactive
        [HttpGet("inactive")]
        [Authorize(Roles = "Sysadmin")]
        public IActionResult GetInactiveUsers()
        {
            var users = _userRepository.GetInactiveUsers();

            // Mapeo manual de usuarios inactivos
            var userDtos = users.Select(user => new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                IsActive = user.IsActive,
                Role = user.Role
            }).ToList();

            return Ok(userDtos);
        }

        // POST: api/User
        [HttpPost]
        [Authorize(Roles = "Sysadmin")]
        public IActionResult CreateUser([FromBody] UserToCreateDTO userToCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid user data." });
            }

            // Mapeo manual del DTO a entidad User
            var user = new User
            {
                Name = userToCreateDto.Name,
                Email = userToCreateDto.Email,
                Password = userToCreateDto.Password,
                IsActive = userToCreateDto.IsActive,
                Role = userToCreateDto.Role
            };

            _userRepository.AddUser(user);

            // Mapeo manual del usuario creado a DTO
            var createdUserDto = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                IsActive = user.IsActive,
                Role = user.Role
            };

            return CreatedAtAction(nameof(GetUserById), new { id = createdUserDto.Id }, createdUserDto);
        }

        // POST: api/User/validate
        [HttpPost("authorization")] // Login
        public ActionResult<string> AuthenticateUser(AuthenticationRequestBody authenticationRequestBody)
        {
            // Validación de credenciales
            var user = _userRepository.ValidateUser(authenticationRequestBody);

            if (user is null)
                return Unauthorized("Invalid credentials or user is not active.");

            // Creación del token JWT
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));
            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
    {
        new Claim("role", user.Role.ToString()),
        new Claim("userId", user.Id.ToString()) // Agregamos el userId como claim
    };

            var jwtSecurityToken = new JwtSecurityToken(
                _config["Authentication:Issuer"],
                _config["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                credentials);

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }

        // PUT: api/User
        [HttpPut]
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult UpdateUser([FromBody] UserDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid user data." });
            }

            // Mapeo manual de DTO a entidad User
            var user = new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email,
                IsActive = userDto.IsActive,
                Role = userDto.Role
            };

            _userRepository.UpdateUser(user);

            return NoContent();
        }

        // PUT: api/User/password
        [HttpPut("password")]
        [Authorize(Roles = "Sysadmin,Investigador")]
        public IActionResult UpdatePassword(int userId, [FromBody] string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                return BadRequest(new { Message = "Password cannot be empty." });
            }

            _userRepository.UpdatePassword(userId, newPassword);
            return NoContent();
        }

        // PUT: api/User/activate/{id}
        [HttpPut("activate/{id}")]
        [Authorize(Roles = "Sysadmin")]
        public IActionResult ActivateUser(int id)
        {
            _userRepository.ActivateUser(id);
            return NoContent();
        }

        // PUT: api/User/inactivate/{id}
        [HttpPut("inactivate/{id}")]
        [Authorize(Roles = "Sysadmin")]
        public IActionResult InactivateUser(int id)
        {
            _userRepository.InactivateUser(id);
            return NoContent();
        }
    }
}
