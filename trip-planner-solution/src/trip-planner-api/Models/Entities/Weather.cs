using MongoDB.Bson.Serialization.Attributes;

namespace TripPlannerApi.Models.Entities
{
    [BsonIgnoreExtraElements]
    public class Weather
    {
        public string Temperature { get; set; } = null!;
        public string Humidity { get; set; } = null!;
        public override string ToString()
        {
            return $"Temp: {Temperature} Hum: {Humidity}";
        }
    }
}
