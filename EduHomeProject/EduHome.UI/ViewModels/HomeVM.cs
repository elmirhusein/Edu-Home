using EduHome.Core.Entities;

namespace EduHome.UI.ViewModels;

public class HomeVM
{
    public IEnumerable<Slider> Sliders { get; set; } = null!;
    public IEnumerable<Notice> Notices { get; set; } = null!;
}
