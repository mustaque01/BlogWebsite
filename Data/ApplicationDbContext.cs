using MongoDB.Driver;
using BlogWebsite.Models;

namespace BlogWebsite.Data;

public class ApplicationDbContext
{
    private readonly IMongoDatabase _database;

    public ApplicationDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoDB"));
        _database = client.GetDatabase("BlogWebsiteDB");
    }

    public IMongoCollection<Blog> Blogs => _database.GetCollection<Blog>("Blogs");
    public IMongoCollection<Comment> Comments => _database.GetCollection<Comment>("Comments");
    public IMongoCollection<Like> Likes => _database.GetCollection<Like>("Likes");
}
