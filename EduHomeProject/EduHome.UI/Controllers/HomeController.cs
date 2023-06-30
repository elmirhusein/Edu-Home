using EduHome.DataAccess.Contexts;
using EduHome.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.UI.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        HomeVM homeVM = new()
        {
            Sliders = await _context.Sliders.ToListAsync(),
        };
        return View(homeVM);
    }
}
