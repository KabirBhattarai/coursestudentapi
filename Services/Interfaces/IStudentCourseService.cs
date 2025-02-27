using efcore.Dtos;
using efcore.Entities;

namespace efcore.Services.Interfaces;

public interface IStudentCourseService
{
    Task<StudentCourse> AddAsync(StudentCourseRequestDto dto);
    Task<StudentCourse> UpdateAsync(int id, StudentCourseRequestDto dto);
    Task DeleteAsync(int id);
}