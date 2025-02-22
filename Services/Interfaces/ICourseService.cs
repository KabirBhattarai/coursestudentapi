using efcore.Dtos;
using efcore.Entities;

namespace efcore.Services.Interfaces;

public interface ICourseService
{
    Task<Course> AddCourseAsync(CourseRequestDto dto);
    Task<Course> UpdateCourseAsync(int id, CourseRequestDto dto);
    Task DeleteCourseAsync(int id);
}