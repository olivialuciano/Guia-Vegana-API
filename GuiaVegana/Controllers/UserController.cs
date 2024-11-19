using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Entities;
using GuiaVegana.Models;
using GuiaVegana.Repositories;
using GuiaVegana.Repositories.Interfaces;
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
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserController(IUserRepository userRepository, IMapper mapper, IConfiguration config)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _config = config;
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound(new { Message = "User not found." });
            }
            var userDto = _mapper.Map<UserDTO>(user);
            return Ok(userDto);
        }

        // GET: api/User
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            var userDtos = _mapper.Map<IEnumerable<UserDTO>>(users);
            return Ok(userDtos);
        }

        // GET: api/User/active
        [HttpGet("active")]
        public IActionResult GetActiveUsers()
        {
            var users = _userRepository.GetActiveUsers();
            var userDtos = _mapper.Map<IEnumerable<UserDTO>>(users);
            return Ok(userDtos);
        }

        // GET: api/User/inactive
        [HttpGet("inactive")]
        public IActionResult GetInactiveUsers()
        {
            var users = _userRepository.GetInactiveUsers();
            var userDtos = _mapper.Map<IEnumerable<UserDTO>>(users);
            return Ok(userDtos);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserToCreateDTO userToCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid user data." });
            }

            var user = _mapper.Map<User>(userToCreateDto);
            _userRepository.AddUser(user);

            var createdUserDto = _mapper.Map<UserDTO>(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUserDto.Id }, createdUserDto);
        }

        // POST: api/User/validate
        [HttpPost("authorization")] //es el login, el usuario inicia sesión.
        public ActionResult<string> AutenticateUser(AuthenticationRequestBody authenticationRequestBody)
        {
            //Validamos las credenciales
            var user = _userRepository.ValidateUser(authenticationRequestBody);
            if (user is null)
                return Unauthorized();

            //Creación el token
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));
            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);
            
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("role", user.Role.ToString())); //agregamos el rol como claim para agarrarlo luegoen le front.

            var jwtSecurityToken = new JwtSecurityToken(
             _config["Authentication:Issuer"],
             _config["Authentication:Audience"],
             claimsForToken,
             DateTime.UtcNow,
             DateTime.UtcNow.AddHours(1),
             credentials);

            var tokenToReturn = new JwtSecurityTokenHandler() //Pasamos el token a string
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);

        }

        // PUT: api/User
        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid user data." });
            }

            var user = _mapper.Map<User>(userDto);
            _userRepository.UpdateUser(user);

            return NoContent();
        }

        // PUT: api/User/password
        [HttpPut("password")]
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
        public IActionResult ActivateUser(int id)
        {
            _userRepository.ActivateUser(id);
            return NoContent();
        }

        // PUT: api/User/inactivate/{id}
        [HttpPut("inactivate/{id}")]
        public IActionResult InactivateUser(int id)
        {
            _userRepository.InactivateUser(id);
            return NoContent();
        }
    }
}
