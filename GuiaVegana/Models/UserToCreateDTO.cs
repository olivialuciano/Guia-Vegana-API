using GuiaVegana.Entities;

namespace GuiaVegana.Models
{
    public class UserToCreateDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public Role Role { get; set; }
    }
}
