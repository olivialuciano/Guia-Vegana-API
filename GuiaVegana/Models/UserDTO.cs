using GuiaVegana.Entities;

namespace GuiaVegana.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public Role Role { get; set; }
    }
}
