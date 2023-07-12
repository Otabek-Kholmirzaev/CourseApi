using CourseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseApi.Data;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<StudentCourses> StudentCourses { get; set; }

    public AppDbContext(DbContextOptions options) 
        : base(options) 
    {
    }
}
