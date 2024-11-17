namespace GuiaVegana.Models
{
    public class OpeningHourDTO
    {
        public int Id { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan OpenTime1 { get; set; }
        public TimeSpan CloseTime1 { get; set; }
        public TimeSpan? OpenTime2 { get; set; }
        public TimeSpan? CloseTime2 { get; set; }
        public int BusinessId { get; set; }
    }
}
