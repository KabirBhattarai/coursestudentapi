using efcore.Data;
using efcore.Dtos;
using efcore.Entities;
using efcore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace efcore.Services;

public class StudentCourseService : IStudentCourseService
{
    private readonly EfcoreDbContext _context;
    
    public StudentCourseService(EfcoreDbContext context)
    {
        _context = context;
    }
    
    public async Task<StudentCourse> AddAsync(StudentCourseRequestDto dto)
    {
        var exists = await _context.StudentCourses
            .AnyAsync(sc => sc.StudentId == dto.StudentId && sc.CourseId == dto.CourseId);

        if (exists)
        {
            throw new Exception("Student is already enrolled in this course.");
        }

        var studentExists = await _context.Students.AnyAsync(s => s.Id == dto.StudentId);
        if (!studentExists)
        {
            throw new Exception("Student not found.");
        }

        var courseExists = await _context.Courses.AnyAsync(c => c.Id == dto.CourseId);
        if (!courseExists)
        {
            throw new Exception("Course not found.");
        }

        var studentCourse = new StudentCourse
        {
            StudentId = dto.StudentId,
            CourseId = dto.CourseId
        };

        _context.StudentCourses.Add(studentCourse);
        await _context.SaveChangesAsync();

        return studentCourse;
    }

    public async Task<StudentCourse> UpdateAsync(int id, StudentCourseRequestDto dto)
    {
        var studentCourse = await _context.StudentCourses.FindAsync(id);
        if (studentCourse == null)
        {
            throw new Exception("StudentCourse not found.");
        }
        
        var studentExists = await _context.Students.AnyAsync(s => s.Id == dto.StudentId);
        if (!studentExists)
        {
            throw new Exception("Student not found.");
        }

        var courseExists = await _context.Courses.AnyAsync(c => c.Id == dto.CourseId);
        if (!courseExists)
        {
            throw new Exception("Course not found.");
        }
        
        var exists = await _context.StudentCourses
            .AnyAsync(sc => sc.StudentId == dto.StudentId && sc.CourseId == dto.CourseId && sc.Id != id);

        if (exists)
        {
            throw new Exception("Student is already enrolled in this course.");
        }

        studentCourse.StudentId = dto.StudentId;
        studentCourse.CourseId = dto.CourseId;

        await _context.SaveChangesAsync();
        return studentCourse;
    }

    public async Task DeleteAsync(int id)
    {
        var studentCourse = await _context.StudentCourses.FindAsync(id);
        if (studentCourse == null)
        {
            throw new Exception("StudentCourse not found.");
        }

        _context.StudentCourses.Remove(studentCourse);
        await _context.SaveChangesAsync();
        
    }
}