using System.Text.Json.Serialization;

namespace GuiaVegana.Models
{
    public class OpeningHourToCreateDTO
    {
        public DayOfWeek Day { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan OpenTime1 { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan CloseTime1 { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan? OpenTime2 { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan? CloseTime2 { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public int BusinessId { get; set; }
    }
}
