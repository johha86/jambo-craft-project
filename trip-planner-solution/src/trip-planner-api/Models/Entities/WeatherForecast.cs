using MongoDB.Bson.Serialization.Attributes;

namespace TripPlannerApi.Models.Entities
{
    [BsonIgnoreExtraElements]
    public class WeatherForecast
    {
        public string Temperature { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public override string ToString()
        {
            return $"Temp: {Temperature} Sum: {Summary}";
        }
    }
}
