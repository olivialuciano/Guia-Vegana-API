using GuiaVegana.Entities;

namespace GuiaVegana.Models
{
    public class BusinessDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string SocialMediaUsername { get; set; }
        public string SocialMediaLink { get; set; }
        public string Address { get; set; }
        public Zone Zone { get; set; }
        public DeliveryType Delivery { get; set; }
        public bool GlutenFree { get; set; }
        public bool AllPlantBased { get; set; }
        public Rating Rating { get; set; }
        public BusinessType BusinessType { get; set; }
        public DateTime LastUpdate { get; set; }
        public int UserId { get; set; }
    }
}
