using AutoMapper;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHome.UI.Areas.EduHomeAdmin.ViewModels.NoticeViewModels;
using EduHome.UI.Areas.EduHomeAdmin.ViewModels.SliderViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.UI.Areas.EduHomeAdmin.Controllers;
[Area("EduHomeAdmin")]

public class NoticeController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public NoticeController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [Area("EduHomeAdmin")]
    public async Task<IActionResult> Index()
    {
        return View(await _context.Notices.ToListAsync());
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
    public async Task<IActionResult> Create(NoticePostVM noticePost)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        Notice notice = _mapper.Map<Notice>(noticePost);
        await _context.Notices.AddAsync(notice);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    [Area("EduHomeAdmin")]
    public async Task<IActionResult> Delete(int Id)
    {
        Notice? noticedb = await _context.Notices.FindAsync(Id);
        if (noticedb == null)
        {
            return NotFound();
        }
        return View(noticedb);
    }
    [Area("EduHomeAdmin")]
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(int Id)
    {
        Notice? noticedb = await _context.Notices.FindAsync(Id);
        if (noticedb == null)
        {
            return NotFound();
        }
        _context.Notices.Remove(noticedb);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
