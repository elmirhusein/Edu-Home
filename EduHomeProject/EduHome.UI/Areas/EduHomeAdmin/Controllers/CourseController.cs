using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHome.UI.Areas.EduHomeAdmin.ViewModels.CourseViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.UI.Areas.EduHomeAdmin.Controllers;
[Area("EduHomeAdmin")]

public class CourseController : Controller
{
    private readonly AppDbContext _context;

    public CourseController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {

        List<Course> courses = await _context.Courses.Include(c => c.CourseCatagory).ToListAsync();
        return View(courses);
    }


    public async Task<IActionResult> Create()
    {
        ViewBag.Catagories = await _context.CourseCatagories.ToListAsync();
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CoursePostVM coursePost, int CatagoryId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var catagory = _context.CourseCatagories.Find(CatagoryId);

        if (catagory is null)
        {
            return BadRequest();
        }

        Course course = new();
        course.Title = coursePost.Title;
        course.Description = coursePost.Description;
        course.ImagePath = coursePost.ImagePath;
        course.CourseCatagoryId = CatagoryId;
        await _context.AddAsync(course);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        var Course = await _context.Courses.FindAsync(id);
        if (Course == null)
        {
            return NotFound();
        }
        return View(Course);
    }
    [HttpPost]
    [Area("EduHomeAdmin")]
    [ActionName("Delete")]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
        var Course = await _context.Courses.FindAsync(id);
        if (Course == null)
        {
            return NotFound();
        }
        _context.Courses.Remove(Course);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

}
