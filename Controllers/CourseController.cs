using efcore.Data;
using efcore.Dtos;
using efcore.Entities;
using efcore.Repositories.Interfaces;
using efcore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcore.Controllers
{
    [Route("api/courses")] 
    [ApiController]
    public class CourseController : ControllerBase 
    {
        private readonly EfcoreDbContext _context;
        private readonly ICourseService _courseService;
        private readonly ICourseRepository _courseRepository;

        public CourseController(EfcoreDbContext context, ICourseService courseService, ICourseRepository courseRepository)
        {
            _context = context;
            _courseService = courseService;
            _courseRepository = courseRepository;
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseRequestDto dto)
        {
            try
            {

               var course = await _courseService.AddCourseAsync(dto);

                return Ok(new 
                    { message = "Successfully created", Id = course.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseRequestDto input)
        {
            try
            {
                var course = await _courseService.UpdateCourseAsync(id, input);

                return Ok(new { message = "Successfully updated", Id = course.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            try
            {
                await _courseService.DeleteCourseAsync(id);

                return Ok(new { message = "Successfully deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            try
            {
                var courses = await _courseRepository.GetCoursesAsync();

                return Ok(new { message = "Courses retrieved successfully", data = courses });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            try
            {
                var course = await _courseRepository.GetCourseByIdAsync(id);
                
                return Ok(new { message = "Course retrieved successfully", data = course });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
