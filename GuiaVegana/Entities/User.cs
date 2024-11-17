using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics;

namespace GuiaVegana.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public Role Role { get; set; }

        // Navigation Properties
        public ICollection<Business> Businesses { get; set; }
        public ICollection<HealthProfessional> HealthProfessionals { get; set; }
        public ICollection<InformativeResource> InformativeResources { get; set; }
        public ICollection<Activism> Activisms { get; set; }
    }
    public enum Role
    {
        Sysadmin,
        Investigador
    }
}
