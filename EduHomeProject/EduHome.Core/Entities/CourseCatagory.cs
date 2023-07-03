using EduHome.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Core.Entities;

public class CourseCatagory : IEntity
{
    public int Id { get ; set ; }
    [Required,MaxLength(50)]    
    public string? Catagory { get ; set ; }
    public ICollection<Course>? Courses { get ; set ; }
}
