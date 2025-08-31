using BlogWebsite.Data;
using BlogWebsite.Models;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;

namespace BlogWebsite.Data;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        // Check if we already have data
        var blogCount = await context.Blogs.CountDocumentsAsync(_ => true);
        if (blogCount > 0)
        {
            return; // DB has been seeded
        }

        // Create a sample user if none exists
        var sampleUser = await userManager.FindByEmailAsync("demo@blog.com");
        if (sampleUser == null)
        {
            sampleUser = new ApplicationUser
            {
                UserName = "demo@blog.com",
                Email = "demo@blog.com",
                EmailConfirmed = true
            };
            await userManager.CreateAsync(sampleUser, "Demo123!");
        }

        // Add sample blogs
        var sampleBlogs = new[]
        {
            new Blog
            {
                Title = "Welcome to Our MongoDB Blog!",
                Content = "This is our first blog post using MongoDB. We're excited to share our thoughts and ideas with you. MongoDB provides excellent scalability and flexibility for our blog platform!",
                AuthorId = sampleUser.Id.ToString(),
                CreatedAt = DateTime.UtcNow.AddDays(-5)
            },
            new Blog
            {
                Title = "Getting Started with MongoDB in ASP.NET Core",
                Content = "MongoDB is a powerful NoSQL database perfect for modern web applications. In this post, we'll explore how to integrate MongoDB with ASP.NET Core for building scalable blog websites.",
                AuthorId = sampleUser.Id.ToString(),
                CreatedAt = DateTime.UtcNow.AddDays(-3)
            },
            new Blog
            {
                Title = "The Future of NoSQL Databases",
                Content = "NoSQL databases like MongoDB are revolutionizing how we store and retrieve data. Their flexible schema and horizontal scaling capabilities make them perfect for modern applications.",
                AuthorId = sampleUser.Id.ToString(),
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            }
        };

        await context.Blogs.InsertManyAsync(sampleBlogs);
    }
}
