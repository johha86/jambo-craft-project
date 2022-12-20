using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TripPlannerApi.Configurations;
using TripPlannerApi.Models.Entities;

namespace TripPlannerApi.DataAccessLayer
{
    public class CitiyRepository : ICitiyRepository
    {
        private readonly IMongoCollection<City> _citiesCollection;

        public CitiyRepository(IOptions<TripPlannerDatabaseSettings> tripPlannerDatabaseSettings)
        {

        }
        public Task<City> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<City> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
