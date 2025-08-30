using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogWebsite.Data;
using BlogWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BlogWebsite.Controllers;

public class BlogController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    
    public BlogController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
    {
        _db = db;
        _userManager = userManager;
    }

    // GET: /Blog
    public async Task<IActionResult> Index()
    {
        var blogs = await _db.Blogs.Include(b => b.Author).OrderByDescending(b => b.CreatedAt).ToListAsync();
        return View(blogs);
    }

    // GET: /Blog/Create
    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Blog/Create
    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Blog model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            model.CreatedAt = DateTime.UtcNow;
            model.AuthorId = user?.Id;
            _db.Blogs.Add(model);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(model);
    }
}
