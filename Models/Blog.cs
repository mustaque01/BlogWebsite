using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace BlogWebsite.Models;

[CollectionName("Blogs")]
public class Blog
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [Required, MaxLength(150)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foreign Key - MongoDB uses ObjectId strings
    public string? AuthorId { get; set; }
    
    [BsonIgnore]
    public ApplicationUser? Author { get; set; }

    [BsonIgnore]
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    
    [BsonIgnore]
    public ICollection<Like> Likes { get; set; } = new List<Like>();
}
