namespace GuiaVegana.Models
{
    public class HealthProfessionalDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string Specialty { get; set; }
        public string License { get; set; }
        public string SocialMediaUsername { get; set; }
        public string SocialMediaLink { get; set; }
        public string WhatsappNumber { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
    }
}
