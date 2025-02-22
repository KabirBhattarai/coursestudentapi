using efcore.Dtos;
using efcore.Entities;

namespace efcore.Services.Interfaces;

public interface IStudentService
{
    Task<Student> AddCourseAsync(StudentRequestDto dto);
    Task<Student> UpdateCourseAsync(int id, StudentRequestDto dto);
    Task DeleteCourseAsync(int id);
}