using EduHome.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Core.Entities;

public class Slider : IEntity
{
    public int Id { get ; set ; }
    [Required, MaxLength(255)]  
    public string BackgroundUrl { get; set; } = null!;
    [Required,MaxLength(30)]
    public string MainTitle { get ; set ; }= null!;
    [Required, MaxLength(30)] public string Title { get; set; } = null!;
    [Required, MaxLength(130)] public string Description { get; set; } = null!;

}
