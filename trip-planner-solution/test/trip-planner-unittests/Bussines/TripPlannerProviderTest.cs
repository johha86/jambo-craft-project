using System.Threading.Tasks;
using TripPlannerApi.DataAccessLayer;
using Xunit;
using Moq;
using System.Collections.Generic;
using TripPlannerApi.Models.Entities;
using System;
using TripPlannerApi.BussinesLayer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TripPlannerApi.Configurations;

namespace TripPlannerApiUnitTests.DataAccess
{
    public class TripPlannerProviderTest
    {
        private readonly Mock<ILogger<TripPlannerProvider>> _loggerMock;
        private readonly IOptions<PollySettings> _someOptions;
        private readonly List<City> _citiesCollection;
        public TripPlannerProviderTest()
        {
            _loggerMock = new Mock<ILogger<TripPlannerProvider>>();
            _someOptions = Options.Create<PollySettings>(new PollySettings() { RetryCount = 4 });

            _citiesCollection = new List<City>
            {
                new City()
                {
                    Id = 1,
                    Name = "Calgary",
                    ShortDescription = "Calgary is the largest city in the western Canadian province of Alberta and the largest metro area of the three Prairie Provinces.",
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

        [Fact]
        public async Task Should_Return_A_Not_Empty_Cities_Collection()
        {
            //  Arrange
            var cityRepoMock = new Mock<ICitiyRepository>();
            cityRepoMock.Setup(e => e.GetAllAsync()).ReturnsAsync(_citiesCollection);
            var tripProvider = new TripPlannerProvider(cityRepoMock.Object, _someOptions, _loggerMock.Object);

            //  Act
            var cities = await tripProvider.GetCitiesAsync();

            //  Assert
            Assert.NotEmpty(cities);
        }

        [Fact]
        public async Task Should_Return_A_Empty_Cities_Collection()
        {
            //  Arrange
            var citiesCollection= new List<City>();
            var cityRepoMock = new Mock<ICitiyRepository>();
            cityRepoMock.Setup(e => e.GetAllAsync()).ReturnsAsync(citiesCollection);
            var tripProvider = new TripPlannerProvider(cityRepoMock.Object, _someOptions, _loggerMock.Object);

            //  Act
            var cities = await tripProvider.GetCitiesAsync();

            //  Assert
            Assert.Empty(cities);
        }

        [Fact]
        public void Should_Throw_ArgumentNullException()
        {
            //  Arrange
            var citiesCollection = new List<City>();
            var cityRepoMock = new Mock<ICitiyRepository>();
            cityRepoMock.Setup(e => e.GetAllAsync()).ReturnsAsync(citiesCollection);

            //  Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TripPlannerProvider(cityRepoMock.Object, null!, _loggerMock.Object));
        }
    }
}