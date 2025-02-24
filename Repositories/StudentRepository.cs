using efcore.Data;
using efcore.Dtos;
using efcore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace efcore.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly EfcoreDbContext _context;

    public StudentRepository(EfcoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<StudentResponseDto>> GetStudentsAsync()
    {
        var students = await _context.Students.Select(s => new StudentResponseDto
        {
            Id = s.Id,
            Name = s.Name,
            Email = s.Email,
            CourseId = s.CourseId
        }).ToListAsync();
        
        return students;
    }

    public async Task<StudentResponseDto?> GetStudentByIdAsync(int id)
    {
        var student = await _context.Students.Where(s => s.Id == id)
            .Select(s => new StudentResponseDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                CourseId = s.CourseId
            }).FirstOrDefaultAsync();

        if (student == null)
        {
            throw new Exception("Student does not exist");
        }
        return student;
    }
}