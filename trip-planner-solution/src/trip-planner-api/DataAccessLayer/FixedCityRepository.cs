using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TripPlannerApi.Configurations;
using TripPlannerApi.Models.Entities;
using System.Threading.Tasks;

namespace TripPlannerApi.DataAccessLayer
{
    public class FixedCityRepository : ICitiyRepository
    {
        private readonly List<City> _citiesCollection;

        public FixedCityRepository()
        {
            _citiesCollection = new List<City>();
            _citiesCollection.Add(new City()
            {
                Id = 1,
                Name = "Calgary",
                ShortDescription = "Calgary is the largest city in the western Canadian province of Alberta and the largest metro area of the three Prairie Provinces.",
                CurrentWeather = CreateNewWeatherForcast(),
                CurrentWeekWeather = CreateNewWeatherForcast()
            });
            _citiesCollection.Add(new City()
            {
                Id = 2,
                Name = "Ottawa",
                ShortDescription = "Ottawa borders Gatineau, Quebec, and forms the core of the Ottawa–Gatineau census metropolitan area (CMA) and the National Capital Region",
                CurrentWeather = CreateNewWeatherForcast(),
                CurrentWeekWeather = CreateNewWeatherForcast()
            });
            _citiesCollection.Add(new City()
            {
                Id = 3,
                Name = "La Habana",
                ShortDescription = "La Habana is the capital and largest city of Cuba.",
                CurrentWeather = CreateNewWeatherForcast(),
                CurrentWeekWeather = CreateNewWeatherForcast()
            });

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
          await Task.FromResult(_citiesCollection.FirstOrDefault(x => x.Id == id)!);

        public async Task<List<City>> GetAllAsync() => 
            await Task.FromResult(_citiesCollection);
    }
}
