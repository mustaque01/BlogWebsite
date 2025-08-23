using Microsoft.AspNetCore.Identity;

namespace BlogWebsite.Models;

public class ApplicationUser : IdentityUser
{
    // Extra profile fields later (Bio, AvatarUrl, etc.)
    public ICollection<Blog>? Blogs { get; set; }
}
