using TripPlannerApi.Models.Entities;

namespace TripPlannerApi.DataAccessLayer
{
    public class RandomWeatherRepository : IWeatherRepository
    {
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
