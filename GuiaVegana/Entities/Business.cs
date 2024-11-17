using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GuiaVegana.Entities
{
    public class Business
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string SocialMediaUsername { get; set; }

        [Url]
        public string SocialMediaLink { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        public Zone Zone { get; set; }

        [Required]
        public DeliveryType Delivery { get; set; }

        [Required]
        public bool GlutenFree { get; set; }

        [Required]
        public Rating Rating { get; set; }

        [Required]
        public BusinessType BusinessType { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<OpeningHour> OpeningHours { get; set; }
        public ICollection<VeganOption> VeganOptions { get; set; }
    }
    public enum Zone
    {
        Norte,
        Sur,
        Oeste,
        Pichincha,
        Centro,
        Pellegrini,
        Abasto
    }

    public enum DeliveryType
    {
        PedidosYa,
        Rappi,
        Propio,
        Otro,
        NoTiene
    }

    public enum Rating
    {
        One = 1,
        Two,
        Three,
        Four,
        Five
    }

    public enum BusinessType
    {
        BarRestaurante,
        Panaderia,
        Heladeria,
        MercadoDietetica
    }

}
