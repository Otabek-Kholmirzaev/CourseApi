using System.ComponentModel.DataAnnotations;

namespace CourseApi.Models;

public class Teacher
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = null!;
    
    [Range(18, 70)]
    public int Age { get; set; }
}