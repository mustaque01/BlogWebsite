using System.ComponentModel.DataAnnotations;

namespace BlogWebsite.Models;

public class Comment
{
    public int Id { get; set; }

    [Required]
    public string Text { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foreign Keys
    public int BlogId { get; set; }
    public Blog? Blog { get; set; }

    public string? UserId { get; set; }
    public ApplicationUser? User { get; set; }
}
