using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHome.UI.Areas.EduHomeAdmin.ViewModels.BlogViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.UI.Areas.EduHomeAdmin.Controllers;

[Area("EduHomeAdmin")]
public class BlogController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public BlogController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [Area("EduHomeAdmin")]
    public async Task<IActionResult> Index()
    {
        return View(await _context.Blogs.ToListAsync());
    }
    [Area("EduHomeAdmin")]
    public IActionResult Create()
    {
        return View();
    }
    [Area("EduHomeAdmin")]
    [HttpPost]
    public async Task<IActionResult> Create(BlogPostVM blogPost)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        Blog blog = _mapper.Map<Blog>(blogPost);
        await _context.Blogs.AddAsync(blog);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Delete(int Id)
    {
        Blog? blogdb = await _context.Blogs.FindAsync(Id);
        if (blogdb == null)
        {
            return NotFound();
        }
        return View(blogdb);
    }
    [Area("EduHomeAdmin")]
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(int Id)
    {
        Blog? blogdb = await _context.Blogs.FindAsync(Id);
        if (blogdb == null)
        {
            return NotFound();
        }
        _context.Blogs.Remove(blogdb);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    [Area("EduHomeAdmin")]
    public async Task<IActionResult> Update(int Id)
    {
        Blog? blogdb = await _context.Blogs.FindAsync(Id);
        if (blogdb == null)
        {
            return NotFound();
        }
        return View(blogdb);

    }
    [Area("EduHomeAdmin")]
    [ActionName("Update")]
    [HttpPost]
    public async Task<IActionResult> Update(int Id, Blog blog)
    {
        if (Id == blog.Id)
        {
            return BadRequest();
        }
        if (!ModelState.IsValid)
        {
            return View(blog);
        }
        Blog? blogdb = await _context.Blogs.AsNoTracking().FirstOrDefaultAsync(s => s.Id == Id);
        if (blogdb == null)
        {
            return NotFound();
        }
        _context.Entry(blog).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

    }
}
