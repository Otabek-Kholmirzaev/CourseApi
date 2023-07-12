using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseApi.Models;

public class Course
{
    public int Id { get; set; }  

    [Required]
    public string Name { get; set; } = null!;
    
    public string? Description { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    public int OwnerId { get; set; }
    
    [JsonIgnore]
    [ForeignKey(nameof(OwnerId))]
    public Teacher? Teacher { get; set; }  
    
    [JsonIgnore]
    public List<StudentCourses>? StudentCourses { get; set; }
}
