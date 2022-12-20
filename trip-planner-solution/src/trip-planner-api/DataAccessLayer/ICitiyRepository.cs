using TripPlannerApi.Models.Entities;

namespace TripPlannerApi.DataAccessLayer
{
    /// <summary>
    /// Interface to be implemented by a class that provide operations on Cities
    /// </summary>
    public interface ICitiyRepository
    {
        public Task<City> Get(Guid id);
        public Task<City> GetAll();
    }
}
