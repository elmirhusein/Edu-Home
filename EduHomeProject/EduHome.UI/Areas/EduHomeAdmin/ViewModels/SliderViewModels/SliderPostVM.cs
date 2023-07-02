using System.ComponentModel.DataAnnotations;

namespace EduHome.UI.Areas.EduHomeAdmin.ViewModels.SliderViewModels;

public class SliderPostVM
{
    [Required, MaxLength(255)]
    public string BackgroundUrl { get; set; } = null!;
    [Required, MaxLength(30)]
    public string MainTitle { get; set; } = null!;
    [Required, MaxLength(30)]
    public string Title { get; set; } = null!;
    [Required, MaxLength(180)]
    public string Description { get; set; } = null!;
}
