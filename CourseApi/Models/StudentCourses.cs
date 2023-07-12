using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseApi.Models;

public class StudentCourses
{
    public int Id { get; set; }
        
    [Range(1, int.MaxValue)]
    public int StudentId { get; set; }
    
    [Range(1, int.MaxValue)]
    public int CourseId { get; set; }
    public DateTime JoinedAt { get; set; } = DateTime.Now;
    
    [JsonIgnore]
    [ForeignKey(nameof(StudentId))]
    public Student? Student { get; set; }
    
    [JsonIgnore]
    [ForeignKey(nameof(CourseId))]
    public Course? Course { get; set; } 
}
