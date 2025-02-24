using efcore.Dtos;
using efcore.Entities;

namespace efcore.Repositories.Interfaces;

public interface IStudentRepository
{
    Task<List<StudentResponseDto>> GetStudentsAsync();
    Task<StudentResponseDto?> GetStudentByIdAsync(int id);
}