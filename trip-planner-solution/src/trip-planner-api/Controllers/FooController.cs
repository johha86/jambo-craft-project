using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TripPlannerApi.Configurations;
using TripPlannerApi.DataAccessLayer;
using TripPlannerApi.Models.DTOs;
using TripPlannerApi.Models.Entities;

namespace TripPlannerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FooController : ControllerBase
    {
        private readonly ILogger<FooController> _logger;
        private readonly IMongoCollection<City> _citiesCollection;

        public FooController(ILogger<FooController> logger, IOptions<TripPlannerDatabaseSettings> tripPlannerDatabaseSettings)
        {
            _logger = logger;

            var mongoClient = new MongoClient(
            tripPlannerDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                tripPlannerDatabaseSettings.Value.DatabaseName);

            _citiesCollection = mongoDatabase.GetCollection<City>(tripPlannerDatabaseSettings.Value.CitiesCollectionName);
        }

        [HttpPost(Name = "seed")]
        public void Post()
        {
            _logger.LogInformation("Seeding DB");

            _citiesCollection.InsertOne(new City()
            {
                Id = 1,
                Name = "Calgary",
                ShortDescription = "Calgary is the largest city in the western Canadian province of Alberta and the largest metro area of the three Prairie Provinces.",
                CurrentWeather = CreateNewWeatherForcast(),
                CurrentWeekWeather = CreateNewWeatherForcast()
            });
            _citiesCollection.InsertOne(new City()
            {
                Id = 2,
                Name = "Ottawa",
                ShortDescription = "Ottawa borders Gatineau, Quebec, and forms the core of the Ottawa–Gatineau census metropolitan area (CMA) and the National Capital Region",
                CurrentWeather = CreateNewWeatherForcast(),
                CurrentWeekWeather = CreateNewWeatherForcast()
            });
            _citiesCollection.InsertOne(new City()
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

        [HttpGet]
        public IEnumerable<CityInfoDto> Get()
        {
            return _citiesCollection.Find(_ => true).ToEnumerable().Select<City, CityInfoDto>(x =>
            new CityInfoDto()
            {
                Name = x.Name,
                ShortDescription = x.ShortDescription,
                CurrentWeather = x.CurrentWeather.ToString(),
                CurrentWeekWeather = x.CurrentWeekWeather.ToString()
            });
            //var list = new List<CityInfoDto>();
            //list.Add(new CityInfoDto() { Name = "Ciudad Foo", CurrentWeather="34", CurrentWeekWeather = "64", ShortDescription = "Lorem Ipsum foo"});
            //return list;
        }
    }
}