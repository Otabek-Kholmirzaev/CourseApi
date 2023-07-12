using CourseApi.Data;
using CourseApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
          if (_context.Courses == null)
          {
              return NotFound();
          }
            return await _context.Courses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            if (_context.Courses == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            if (_context.Courses == null)
            {
                return Problem("Entity set 'AppDbContext.Courses'  is null.");
            }
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            if (_context.Courses == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}/Students")]
        public async Task<ActionResult<List<Student>>> GetStudents(int id)
        {
            var course = _context.Courses.Include(x => x.StudentCourses).ThenInclude(x => x.Student)
                .FirstOrDefault(x => x.Id == id);
            
            if (course == null)
            {
                return NotFound();
            }

            var students = course.StudentCourses.Select(x => x.Student).ToList();
            
            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

        [HttpPost("{id}/Add-Student/{studentId}")]
        public async Task<IActionResult> AddStudent(int id, int studentId)
        {
            var studentCourse = new StudentCourses
            {
                StudentId = studentId,
                CourseId = id
            };

            _context.StudentCourses.Add(studentCourse);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}/Remove-Student/{studentId}")]
        public async Task<IActionResult> RemoveStudent(int id, int studentId)
        {
            var studentCourse = await _context.StudentCourses.FirstOrDefaultAsync(x =>
                x.StudentId == studentId && x.CourseId == id);

            if (studentCourse == null)
            {
                return NotFound();
            }

            _context.StudentCourses.Remove(studentCourse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return (_context.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
