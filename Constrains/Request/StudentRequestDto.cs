using efcore.Entities;

namespace efcore.Dtos;

public class StudentRequestDto
{
    public string? Name { get; set; }
    public int CourseId { get; set; }
    
}