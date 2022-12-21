namespace TripPlannerApi.Models.DTOs
{
    public record CityInfoDto
    {
        public string Name { get; init; } = null!;
        public string ShortDescription { get; init; } = null!;
        public string CurrentWeather { get; init; } = null!;
        public string CurrentWeekWeather { get; init; } = null!;
    }
}
