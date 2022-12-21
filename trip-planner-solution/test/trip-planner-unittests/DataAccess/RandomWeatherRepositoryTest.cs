using System.Threading.Tasks;
using TripPlannerApi.DataAccessLayer;
using Xunit;

namespace TripPlannerApiUnitTests.DataAccess
{
    public class RandomWeatherRepositoryTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task Should_Return_A_Current_Weather_By_City_Id(int cityId)
        {
            //  Arrange
            var weatherRepo = new RandomWeatherRepository();

            //  Act
            var weatherForcast = await weatherRepo.GetCurrentWeatherForCity(cityId);

            //  Assert
            Assert.False(string.IsNullOrEmpty(weatherForcast.Temperature));
            Assert.False(string.IsNullOrEmpty(weatherForcast.Summary));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task Should_Return_A_Current_Week_Weather_By_City_Id(int cityId)
        {
            //  Arrange
            var weatherRepo = new RandomWeatherRepository();

            //  Act
            var weatherForcast = await weatherRepo.GetCurrentWeekWeatherForCity(cityId);

            //  Assert
            Assert.False(string.IsNullOrEmpty(weatherForcast.Temperature));
            Assert.False(string.IsNullOrEmpty(weatherForcast.Summary));
        }
    }
}