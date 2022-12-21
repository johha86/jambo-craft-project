namespace TripPlannerApi.Integration
{
    /// <summary>
    /// Background service to retrieve the weather information and save it into the database.
    /// </summary>
    public class WeatherForcastBackgroundService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.CompletedTask;
        }
    }
}
