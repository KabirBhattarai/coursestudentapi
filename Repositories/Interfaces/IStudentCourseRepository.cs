using efcore.Dtos;

namespace efcore.Repositories.Interfaces;

public interface IStudentCourseRepository
{
    Task<List<StudentCourseResponseDto>> GetAllAsync();
    Task<StudentCourseResponseDto?> GetByIdAsync(int id);
}