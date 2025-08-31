using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace BlogWebsite.Models;

[CollectionName("Likes")]
public class Like
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    public string BlogId { get; set; } = string.Empty;
    
    [BsonIgnore]
    public Blog? Blog { get; set; }

    public string? UserId { get; set; }
    
    [BsonIgnore]
    public ApplicationUser? User { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
