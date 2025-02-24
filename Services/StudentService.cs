using efcore.Data;
using efcore.Dtos;
using efcore.Entities;
using efcore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace efcore.Services;

public class StudentService : IStudentService
{
    private readonly EfcoreDbContext _context;

    public StudentService(EfcoreDbContext context)
    {
        _context = context;
    }
    
    public async Task<Student> AddStudentAsync(StudentRequestDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new Exception("Name is required");
        }
                
        var courseExists = await _context.Courses.AnyAsync(c => c.Id == dto.CourseId);
        if (!courseExists)
        {
            throw new Exception("Course does not exist");
        }

        var student = new Student
        {
            Name = dto.Name,
            Email = dto.Email,
            CourseId = dto.CourseId
        };

        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        
        return student;
    }

    public async Task<Student> UpdateStudentAsync(int id, StudentRequestDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new Exception("Name is required");
        }

        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            throw new Exception("Student does not exist");
        }

        var courseExists = await _context.Courses.AnyAsync(c => c.Id == dto.CourseId);
        if (!courseExists)
        {
            throw new Exception("Course does not exist");
        }

        student.Name = dto.Name;
        student.Email = dto.Email;
        student.CourseId = dto.CourseId;
        await _context.SaveChangesAsync();
        
        return student;
    }

    public async Task DeleteStudentAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            throw new Exception("Student does not exist");
        }

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
    }
}