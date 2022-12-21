using System.Threading.Tasks;
using TripPlannerApi.DataAccessLayer;
using Xunit;

namespace TripPlannerApiUnitTests.DataAccess
{
    public class FixedCityRepositoryTest
    {
        [Fact]
        public async Task Should_Return_A_Valid_City()
        {
            //  Arrange
            const int cityId = 1;
            var cityRepo = new FixedCityRepository();

            //  Act
            var city = await cityRepo.GetAsync(cityId);

            //  Assert
            Assert.Equal(cityId, city.Id);
            Assert.False(string.IsNullOrEmpty(city.Name));
        }

        [Fact]
        public async Task Should_Not_Return_A_Valid_City()
        {
            //  Arrange
            const int cityId = 42;
            var cityRepo = new FixedCityRepository();

            //  Act
            var city = await cityRepo.GetAsync(cityId);

            //  Assert
            Assert.Null(city);
        }
    }
}