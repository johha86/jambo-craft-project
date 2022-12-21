using TripPlannerApi.Models.Entities;

namespace TripPlannerApi.DataAccessLayer
{
    public class RandomWeatherRepository : IWeatherRepository
    {
        public static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<Weather> GetCurrentWeatherForCity(int id) =>
            await Task.FromResult(CreateNewWeatherForcast());

        public async Task<Weather> GetCurrentWeekWeatherForCity(int id) =>
            await Task.FromResult(CreateNewWeatherForcast());

        static Weather CreateNewWeatherForcast()
        {
            return new Weather()
            {
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Temperature = Random.Shared.Next(-20, 55).ToString()
            };
        }
    }
}
