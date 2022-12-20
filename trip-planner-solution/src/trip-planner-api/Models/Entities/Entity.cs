using MongoDB.Bson.Serialization.Attributes;

namespace TripPlannerApi.Models.Entities
{
    /// <summary>
    /// Base class for any entity BSON
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Id of the entitty.
        /// Note: The data type is more precise with <see cref="Guid"/> data type.
        /// </summary>
        [BsonId]
        public int Id { get; set; }

        public string? ETag { get; set; }
    }
}
