using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GuiaVegana.Entities
{
    public class HealthProfessional
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Specialty { get; set; }

        [MaxLength(50)]
        public string License { get; set; }

        [MaxLength(50)]
        public string SocialMediaUsername { get; set; }

        [Url]
        public string SocialMediaLink { get; set; }

        [MaxLength(15)]
        public string WhatsappNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        // Navigation Properties
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
