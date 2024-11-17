using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GuiaVegana.Entities
{
    public class Activism
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Contact { get; set; }

        [MaxLength(50)]
        public string SocialMediaUsername { get; set; }

        [Url]
        public string SocialMediaLink { get; set; }

        public string Description { get; set; }

        // Navigation Properties
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
