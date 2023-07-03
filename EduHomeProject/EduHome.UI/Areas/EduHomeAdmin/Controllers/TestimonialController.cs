using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHome.UI.Areas.EduHomeAdmin.ViewModels.TestimonialViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.UI.Areas.EduHomeAdmin.Controllers;
[Area("EduHomeAdmin")]

public class TestimonialController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _env;

    public TestimonialController(AppDbContext context, IMapper mapper, IWebHostEnvironment env)
    {
        _context = context;
        _mapper = mapper;
        _env = env;
    }
    [Area("EduHomeAdmin")]
    public async Task<IActionResult> Index()
    {

        List<Testimonial> testimonials = await _context.Testimonials.ToListAsync();
        return View(testimonials);
    }
    [Area("EduHomeAdmin")]
    public async Task<IActionResult> Create()
    {
        ViewBag.Catagories = await _context.Testimonials.ToListAsync();
        return View();
    }
    [Area("EduHomeAdmin")]
    [HttpPost]
    [ActionName("Create")]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(Testimonial testimonial)

    {
        if (!ModelState.IsValid)
        {
            return View(testimonial);
        }
        var testimonialdb = new Testimonial
        {
            ImagePath = testimonial.ImagePath,
            Surname = testimonial.Surname,
            Name = testimonial.Name,
            Position = testimonial.Position,
            Description = testimonial.Description
        };
        await _context.Testimonials.AddAsync(testimonialdb);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

    }
    [Area("EduHomeAdmin")]
    public async Task<IActionResult> Delete(int id)
    {
        var testimonial = await _context.Testimonials.FindAsync(id);
        if (testimonial == null)
        {
            return NotFound();
        }
        return View(testimonial);
    }
    [Area("EduHomeAdmin")]
    [HttpPost]
    [ActionName("Delete")]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
        var testimonials = await _context.Testimonials.FindAsync(id);
        if (testimonials == null)
        {
            return NotFound();
        }
        _context.Testimonials.Remove(testimonials);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    [Area("EduHomeAdmin")]

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var testimonials = await _context.Testimonials.FindAsync(id);
        if (testimonials == null)
        {
            return NotFound();
        }

        var testimoniaVM = new TestimonialPostVM
        {
            Name = testimonials.Name,
            Surname = testimonials.Surname,
            Position = testimonials.Position,
            Description = testimonials.Description
        };

        return View(testimoniaVM);
    }
    [Area("EduHomeAdmin")]
    [ActionName("Update")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, TestimonialPostVM testimoniaVM)
    {
        if (id != testimoniaVM.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(testimoniaVM);
        }

        Testimonial Testimonials = await _context.Testimonials.FindAsync(id);
        if (Testimonials == null)
        {
            return BadRequest();
        }
        Testimonials.Name = testimoniaVM.Name;
        Testimonials.Surname = testimoniaVM.Surname;
        Testimonials.Position = testimoniaVM.Position;
        Testimonials.ImagePath = testimoniaVM.ImagePath;
        Testimonials.Description = testimoniaVM.Description;
        _context.Entry(Testimonials).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}


