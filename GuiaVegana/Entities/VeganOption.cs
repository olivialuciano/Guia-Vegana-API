using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GuiaVegana.Entities
{
    public class VeganOption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(10)]
        public decimal Price { get; set; }

        // Navigation Properties
        public int BusinessId { get; set; }

        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
    }
}
