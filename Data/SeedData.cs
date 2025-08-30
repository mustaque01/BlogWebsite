using BlogWebsite.Data;
using BlogWebsite.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogWebsite.Data;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        // Ensure database is created
        await context.Database.EnsureCreatedAsync();

        // Check if we already have data
        if (context.Blogs.Any())
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
                Title = "Welcome to Our Blog!",
                Content = "This is our first blog post. We're excited to share our thoughts and ideas with you. Stay tuned for more interesting content coming your way!",
                AuthorId = sampleUser.Id,
                CreatedAt = DateTime.UtcNow.AddDays(-5)
            },
            new Blog
            {
                Title = "Getting Started with ASP.NET Core",
                Content = "ASP.NET Core is a powerful framework for building web applications. In this post, we'll explore the basics of creating a blog website using MVC pattern, Entity Framework, and Identity for authentication.",
                AuthorId = sampleUser.Id,
                CreatedAt = DateTime.UtcNow.AddDays(-3)
            },
            new Blog
            {
                Title = "The Future of Web Development",
                Content = "Web development is constantly evolving. From static websites to dynamic applications, we've come a long way. Let's discuss the trends and technologies shaping the future of web development.",
                AuthorId = sampleUser.Id,
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            }
        };

        context.Blogs.AddRange(sampleBlogs);
        await context.SaveChangesAsync();
    }
}
