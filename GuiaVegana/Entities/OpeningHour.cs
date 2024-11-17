using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GuiaVegana.Entities
{
    public class OpeningHour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DayOfWeek Day { get; set; }

        [Required]
        public TimeSpan OpenTime1 { get; set; }

        [Required]
        public TimeSpan CloseTime1 { get; set; }

        public TimeSpan? OpenTime2 { get; set; }
        public TimeSpan? CloseTime2 { get; set; }

        // Navigation Properties
        public int BusinessId { get; set; }

        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
    }
}
