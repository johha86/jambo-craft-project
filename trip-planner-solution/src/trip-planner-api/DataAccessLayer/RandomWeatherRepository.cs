using TripPlannerApi.Models.Entities;

namespace TripPlannerApi.DataAccessLayer
{
    /// <summary>
    /// Implementation of a <see cref="IWeatherRepository"/> that provide weather forcast for a city
    /// without connect to a database or external provider. An alternative could be use a BackgroundService
    /// that fetch periodically the forecast information and update it into the <see cref="City"/> object inside DB.
    /// </summary>
    public class RandomWeatherRepository : IWeatherRepository
    {
        public static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<WeatherForecast> GetCurrentWeatherForCity(int id) =>
            await Task.FromResult(CreateNewWeatherForcast());

        public async Task<WeatherForecast> GetCurrentWeekWeatherForCity(int id) =>
            await Task.FromResult(CreateNewWeatherForcast());

        static WeatherForecast CreateNewWeatherForcast()
        {
            return new WeatherForecast()
            {
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Temperature = Random.Shared.Next(-20, 55).ToString()
            };
        }
    }
}
