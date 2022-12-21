using TripPlannerApi.Models.Entities;

namespace TripPlannerApi.DataAccessLayer
{
    /// <summary>
    /// City repository that doesnt use any connection and operate with fixed cities.
    /// </summary>
    public class FixedCityRepository : ICitiyRepository
    {
        private readonly List<City> _citiesCollection;

        public FixedCityRepository()
        {
            _citiesCollection = new List<City>
            {
                new City()
                {
                    Id = 1,
                    Name = "Calgary",
                    ShortDescription = "Calgary is the largest city in the western Canadian province of Alberta and the largest metro area of the three Prairie Provinces.",
                    CurrentWeather = CreateNewWeatherForcast(),
                    CurrentWeekWeather = CreateNewWeatherForcast()
                },
                new City()
                {
                    Id = 2,
                    Name = "Ottawa",
                    ShortDescription = "Ottawa borders Gatineau, Quebec, and forms the core of the Ottawa–Gatineau census metropolitan area (CMA) and the National Capital Region",
                    CurrentWeather = CreateNewWeatherForcast(),
                    CurrentWeekWeather = CreateNewWeatherForcast()
                },
                new City()
                {
                    Id = 3,
                    Name = "La Habana",
                    ShortDescription = "La Habana is the capital and largest city of Cuba.",
                    CurrentWeather = CreateNewWeatherForcast(),
                    CurrentWeekWeather = CreateNewWeatherForcast()
                }
            };

            static Weather CreateNewWeatherForcast()
            {
                return new Weather()
                {
                    Summary = RandomWeatherRepository.Summaries[Random.Shared.Next(RandomWeatherRepository.Summaries.Length)],
                    Temperature = Random.Shared.Next(-20, 55).ToString()
                };
            }
        }

        public async Task<City> GetAsync(int id) =>
          await Task.FromResult(result: _citiesCollection.Find(x => x.Id == id)!);

        public async Task<List<City>> GetAllAsync() =>
            await Task.FromResult(_citiesCollection);
    }
}
