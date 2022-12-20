using TripPlannerApi.Models.Entities;

namespace TripPlannerApi.DataAccessLayer
{
    /// <summary>
    /// Interface to be implemented by a class that provide weather information
    /// </summary>
    public interface IWeatherRepository
    {
        public Task<Weather> GetCurrentWeatherForCity(int id);
        public Task<Weather> GetCurrentWeekWeatherForCity(int id);
    }
}
