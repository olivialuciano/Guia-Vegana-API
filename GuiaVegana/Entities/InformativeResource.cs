using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GuiaVegana.Entities
{
    public class InformativeResource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(700)]
        public string? Image { get; set; }

        [Required]
        [MaxLength(50)]
        public string Topic { get; set; }

        [MaxLength(500)]
        public string Platform { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public ResourceType Type { get; set; } // Enum property


        // Navigation Properties
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
public enum ResourceType
{
    Book,
    Documentary,
    WebResource
}