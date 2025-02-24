using efcore.Entities;

namespace efcore.Dtos;

public class StudentResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public int? CourseId { get; set; }
    
}