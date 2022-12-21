using TripPlannerApi.Models.DTOs;

namespace TripPlannerApi.BussinesLayer
{
    /// <summary>
    /// Interface to be implemented by a class that provide Trip Planner options.
    /// </summary>
    public interface ITripPlannerProvider
    {
        public Task<IEnumerable<CityInfoDto>> GetCitiesAsync();
    }
}
