using efcore.Data;
using efcore.Dtos;
using efcore.Repositories.Interfaces;
using efcore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace efcore.Controllers;

[Route("api/studentcourses")] 
[ApiController]
public class StudentCourseController : ControllerBase
{
    private readonly IStudentCourseRepository _studentCourseRepository;
    private readonly EfcoreDbContext _context;
    private readonly IStudentCourseService _studentCourseService;

    public StudentCourseController(IStudentCourseRepository studentCourseRepository, EfcoreDbContext context, IStudentCourseService studentCourseService)
    {
        _studentCourseRepository = studentCourseRepository;
        _context = context;
        _studentCourseService = studentCourseService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StudentCourseRequestDto dto)
    {
        try
        {

            var studentcourse = await _studentCourseService.AddAsync(dto);

            return Ok(new 
                { message = "Successfully created", data = studentcourse });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] StudentCourseRequestDto dto)
    {
        try
        {
            var updated = await _studentCourseService.UpdateAsync(id, dto);

            return Ok(new { message = "Successfully updated" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _studentCourseService.DeleteAsync(id);

            return Ok(new { message = "Successfully deleted" });

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var studentcourses = await _studentCourseRepository.GetAllAsync();

            return Ok(new { message = "retrieved successfully", data = studentcourses });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

        
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var studentcourse = await _studentCourseRepository.GetByIdAsync(id);
                
            return Ok(new { message = "retrieved successfully", data = studentcourse });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}