using efcore.Data;
using efcore.Dtos;
using efcore.Entities;
using efcore.Services.Interfaces;

namespace efcore.Services;

public class CourseService : ICourseService
{
    private readonly EfcoreDbContext _context;
    
    public CourseService(EfcoreDbContext context)
    {
        _context = context;
    }
    public async Task<Course> AddCourseAsync(CourseRequestDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new Exception("Name is required");
        }        

        var course = new Course
        {
            Name = dto.Name
        };

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
        
        return course;
    }

    public async Task<Course> UpdateCourseAsync(int id, CourseRequestDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new Exception("Name is required");
        }
                    

        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            throw new Exception("course not found");
        }
        
        course.Name = dto.Name;
        await _context.SaveChangesAsync();
        return course;
    }

    public async Task DeleteCourseAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            throw new Exception("course not found");
        }
                    

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();

        
    }
}