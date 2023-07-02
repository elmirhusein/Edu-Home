using System.ComponentModel.DataAnnotations;

namespace EduHome.UI.Areas.EduHomeAdmin.ViewModels.NoticeViewModels;

public class NoticePostVM
{
    public DateTime Date { get; set; } 
    [Required, MaxLength(180)]
    public string Description { get; set; } = null!;
}
