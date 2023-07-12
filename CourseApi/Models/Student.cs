using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CourseApi.Models;

public class Student
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = null!;
    
    [Range(7, 40)]
    public int Age { get; set; }
    
    [JsonIgnore]
    public List<StudentCourses>? StudentCourses { get; set; } 
}
