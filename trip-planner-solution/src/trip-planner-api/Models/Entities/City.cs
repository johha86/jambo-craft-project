using MongoDB.Bson.Serialization.Attributes;

namespace TripPlannerApi.Models.Entities
{
    [BsonIgnoreExtraElements]
    public class City : Entity
    {
        //  The versioning approach can be improved with Mongo Realm
        public const string VERSION = "2022-12-20";

        public string Version { get; set; } = VERSION;

        public string Name { get; set; } = null!;

        public string ShortDescription { get; set; } = null!;

        public WeatherForecast CurrentWeather { get; set; } = null!;

        public WeatherForecast CurrentWeekWeather { get; set; } = null!;
    }
}
