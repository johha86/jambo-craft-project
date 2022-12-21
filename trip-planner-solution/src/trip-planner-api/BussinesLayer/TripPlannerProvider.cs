using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;
using TripPlannerApi.Configurations;
using TripPlannerApi.DataAccessLayer;
using TripPlannerApi.Models.DTOs;

namespace TripPlannerApi.BussinesLayer
{
    /// <summary>
    /// Trip Planner provider that handle the bussines logic of the system.
    /// </summary>
    public class TripPlannerProvider : ITripPlannerProvider
    {
        /// <summary>
        /// City repository
        /// </summary>
        private readonly ICitiyRepository _cityRepository;
        /// <summary>
        /// Polly Retry Policy
        /// </summary>
        private readonly AsyncRetryPolicy<IEnumerable<CityInfoDto>> _getCitiesRetryPolicy;

        public TripPlannerProvider(ICitiyRepository cityRepository, IOptions<PollySettings> pollySettings, ILogger<TripPlannerProvider> logger)
        {
            _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
            if (pollySettings == null)
                throw new ArgumentNullException(nameof(pollySettings));
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            _getCitiesRetryPolicy = Policy<IEnumerable<CityInfoDto>>
                .Handle<Exception>()
                .RetryAsync(pollySettings.Value.RetryCount, onRetry: (exception, retryCount) => logger.LogInformation("Retrying after {exception} with retry counter in {retryCount} time(s).", exception, retryCount));
        }

        public async Task<IEnumerable<CityInfoDto>> GetCitiesAsync()
        {
            var result = await _getCitiesRetryPolicy.ExecuteAsync(async () =>
            {
                return (await _cityRepository.GetAllAsync()).Select(x =>
                new CityInfoDto()
                {
                    Name = x.Name,
                    ShortDescription = x.ShortDescription,
                    CurrentWeather = x.CurrentWeather.ToString(),
                    CurrentWeekWeather = x.CurrentWeekWeather.ToString()
                });
            });
            return result;
        }
    }
}
