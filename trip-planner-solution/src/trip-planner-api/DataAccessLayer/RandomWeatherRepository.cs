using TripPlannerApi.Models.Entities;

namespace TripPlannerApi.DataAccessLayer
{
    public class RandomWeatherRepository : IWeatherRepository
    {
        public static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<Weather> GetCurrentWeatherForCity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Weather> GetCurrentWeekWeatherForCity(int id)
        {
            throw new NotImplementedException();
        }
    }
}
