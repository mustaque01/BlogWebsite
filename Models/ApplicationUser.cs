using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace BlogWebsite.Models;

[CollectionName("Users")]
public class ApplicationUser : MongoIdentityUser<Guid>
{
    // Extra profile fields later (Bio, AvatarUrl, etc.)
    public ICollection<Blog>? Blogs { get; set; }
}
