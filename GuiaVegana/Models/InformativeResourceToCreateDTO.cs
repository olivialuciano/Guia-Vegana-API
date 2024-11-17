namespace GuiaVegana.Models
{
    public class InformativeResourceToCreateDTO
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public string Topic { get; set; }
        public string Platform { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
