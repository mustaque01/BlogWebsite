using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace BlogWebsite.Models;

[CollectionName("Comments")]
public class Comment
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [Required]
    public string Text { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foreign Keys - MongoDB uses ObjectId strings
    public string BlogId { get; set; } = string.Empty;
    
    [BsonIgnore]
    public Blog? Blog { get; set; }

    public string? UserId { get; set; }
    
    [BsonIgnore]
    public ApplicationUser? User { get; set; }
}
