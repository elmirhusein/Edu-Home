using System.ComponentModel.DataAnnotations;

namespace EduHome.UI.Areas.EduHomeAdmin.ViewModels.BlogViewModels;

public class BlogPostVM
{
    [Required, MaxLength(255)]
    public string ImagePath { get; set; } = null!;
    [Required, MaxLength(40)]
    public string Name { get; set; } = null!;
    public DateTime Date { get; set; }
    public int Box { get; set; }
    [Required, MaxLength(200)]
    public string Description { get; set; } = null!;
}
