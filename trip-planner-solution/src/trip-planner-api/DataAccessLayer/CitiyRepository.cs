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
            var mongoClient = new MongoClient(
            tripPlannerDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                tripPlannerDatabaseSettings.Value.DatabaseName);

            _citiesCollection = mongoDatabase.GetCollection<City>(tripPlannerDatabaseSettings.Value.CitiesCollectionName);
        }

        public async Task<City> GetAsync(int id) =>
          await (await _citiesCollection.FindAsync(x => x.Id == id)).FirstOrDefaultAsync();

        public async Task<List<City>> GetAllAsync() =>        
            await (await _citiesCollection.FindAsync(_ => true)).ToListAsync();

    }
}
