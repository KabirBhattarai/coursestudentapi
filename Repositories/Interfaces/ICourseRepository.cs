using efcore.Dtos;
using efcore.Entities;

namespace efcore.Repositories.Interfaces;

public interface ICourseRepository
{
    Task<List<CourseResponseDto>> GetCoursesAsync();
    Task<CourseResponseDto?> GetCourseByIdAsync(int id);
}