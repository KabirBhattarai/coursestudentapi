using efcore.Data;
using efcore.Dtos;
using efcore.Entities;
using efcore.Repositories.Interfaces;
using efcore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcore.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly EfcoreDbContext _context;
        private readonly IStudentService _studentService;
        private readonly IStudentRepository _studentRepository;

        public StudentController(EfcoreDbContext context, IStudentService studentService, IStudentRepository studentRepository)
        {
            _context = context;
            _studentService = studentService;
            _studentRepository = studentRepository;
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentRequestDto dto)
        {
            try
            {
                var student = await _studentService.AddStudentAsync(dto);
                
                return Ok(new { message = "Successfully created", Id = student.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentRequestDto dto)
        {
            try
            {
                var student = await _studentService.UpdateStudentAsync(id, dto);

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
                await _studentService.DeleteStudentAsync(id);

                return Ok(new { message = "Successfully deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await _studentRepository.GetStudentsAsync();
                
                return Ok(new { message = "Successfully retrieved", students = students });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var student = await _studentRepository.GetStudentByIdAsync(id);
                
                return Ok(new { message = "Successfully retrieved", data = student });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
