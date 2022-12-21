using TripPlannerApi.Models.Entities;

namespace TripPlannerApi.DataAccessLayer
{
    /// <summary>
    /// Interface to be implemented by a class that provide operations on Cities.
    /// </summary>
    public interface ICitiyRepository
    {
        public Task<City> GetAsync(int id);
        public Task<List<City>> GetAllAsync();
    }
}
