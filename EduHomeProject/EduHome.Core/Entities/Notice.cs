using EduHome.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Core.Entities;

public class Notice : IEntity
{
    public int Id { get ; set ; }
    public DateTime Date { get; set ; }
    [Required,MaxLength(180)]
    public string Description { get; set ; }
}
