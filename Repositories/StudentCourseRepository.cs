using efcore.Data;
using efcore.Dtos;
using efcore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace efcore.Repositories;

public class StudentCourseRepository : IStudentCourseRepository
{
    private readonly EfcoreDbContext _context;

    public StudentCourseRepository(EfcoreDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<StudentCourseResponseDto>> GetAllAsync()
    {
        var studentCourses = await _context.StudentCourses
            .Select(sc => new StudentCourseResponseDto
            {
                Id = sc.Id,
                StudentId = sc.StudentId,
                StudentName = sc.Student.Name,
                CourseId = sc.CourseId,
                CourseName = sc.Course.Name
            })
            .ToListAsync();
        
        return studentCourses;
        
    }

    public async Task<StudentCourseResponseDto?> GetByIdAsync(int id)
    {
        var studentcourse = await _context.StudentCourses
            .Where(sc => sc.Id == id)
            .Select(sc => new StudentCourseResponseDto
            {
                Id = sc.Id,
                StudentId = sc.StudentId,
                StudentName = sc.Student.Name,
                CourseId = sc.CourseId,
                CourseName = sc.Course.Name
            })
            .FirstOrDefaultAsync();
        
        return studentcourse;
    }
}