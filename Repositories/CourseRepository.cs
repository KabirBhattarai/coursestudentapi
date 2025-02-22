using efcore.Data;
using efcore.Dtos;
using efcore.Entities;
using efcore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace efcore.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly EfcoreDbContext _context;

    public CourseRepository(EfcoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<CourseResponseDto>> GetCoursesAsync()
    {
        var courses = await _context.Courses
            .Select(c => new CourseResponseDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync(); 
        return courses;
    }

    public async Task<CourseResponseDto?> GetCourseByIdAsync(int id)
    {
        var course = await _context.Courses
            .Where(c => c.Id == id)
            .Select(c => new CourseResponseDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .FirstOrDefaultAsync();

        if (course == null)
        {
            throw new Exception("Course not found");
        }
         
        return course;
        
    }
}