namespace TripPlannerApi.Models.DTOs
{
    public record TripPlannerDto
    {
        public IEnumerable<CityInfoDto> CitiesInfo { get; init; } = null!;
    }
}
