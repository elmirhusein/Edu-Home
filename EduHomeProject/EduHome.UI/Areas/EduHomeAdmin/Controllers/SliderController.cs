using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHome.UI.Areas.EduHomeAdmin.ViewModels.SliderViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.UI.Areas.EduHomeAdmin.Controllers;
[Area("EduHomeAdmin")]

public class SliderController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public SliderController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [Area("EduHomeAdmin")]
    public async Task<IActionResult> Index()
    {
        return View(await _context.Sliders.ToListAsync());
    }
    [Area("EduHomeAdmin")]
    public IActionResult Create()
    {
        return View();
    }
    [Area("EduHomeAdmin")]
    [HttpPost]
    [ActionName("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SliderPostVM sliderPost)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        Slider slider = _mapper.Map<Slider>(sliderPost);
        await _context.Sliders.AddAsync(slider);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    [Area("EduHomeAdmin")]
    public async Task<IActionResult> Delete(int Id)
    {
        Slider? sliderdb = await _context.Sliders.FindAsync(Id);
        if (sliderdb == null)
        {
            return NotFound();
        }
        return View(sliderdb);
    }
    [Area("EduHomeAdmin")]
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(int Id)
    {
        Slider? sliderdb = await _context.Sliders.FindAsync(Id);
        if (sliderdb == null)
        {
            return NotFound();
        }
        _context.Sliders.Remove(sliderdb);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

}
