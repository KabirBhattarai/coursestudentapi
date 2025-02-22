using efcore.Data;
using efcore.Dtos;
using efcore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcore.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly EfcoreDbContext _context;

        public StudentController(EfcoreDbContext context)
        {
            _context = context;
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentRequestDto input)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(input.Name))
                {
                    throw new Exception("Name is required");
                }
                   

                
                var courseExists = await _context.Courses.AnyAsync(c => c.Id == input.CourseId);
                if (!courseExists)
                {
                    throw new Exception("Course does not exist");
                }

                var student = new Student
                {
                    Name = input.Name,
                    CourseId = input.CourseId
                };

                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Successfully created", Id = student.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentRequestDto input)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input.Name))
                {
                    throw new Exception("Name is required");
                }
                    

                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    throw new Exception("Student does not exist");
                }
                   

                var courseExists = await _context.Courses.AnyAsync(c => c.Id == input.CourseId);
                if (!courseExists)
                {
                    throw new Exception("Course does not exist");
                }

                student.Name = input.Name;
                student.CourseId = input.CourseId;
                await _context.SaveChangesAsync();

                return Ok(new { message = "Successfully updated", Id = student.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    throw new Exception("Student does not exist");
                }

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Successfully deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
