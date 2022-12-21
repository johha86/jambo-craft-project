namespace TripPlannerApi.Configurations
{
    public class TripPlannerDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string CitiesCollectionName { get; set; } = null!;
    }
}
