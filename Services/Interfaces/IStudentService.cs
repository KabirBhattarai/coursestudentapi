using efcore.Dtos;
using efcore.Entities;

namespace efcore.Services.Interfaces;

public interface IStudentService
{
    Task<Student> AddStudentAsync(StudentRequestDto dto);
    Task<Student> UpdateStudentAsync(int id, StudentRequestDto dto);
    Task DeleteStudentAsync(int id);
}