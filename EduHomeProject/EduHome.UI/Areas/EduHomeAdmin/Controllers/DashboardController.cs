using Microsoft.AspNetCore.Mvc;

namespace EduHome.UI.Areas.EduHomeAdmin.Controllers;

[Area("EduHomeAdmin")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
