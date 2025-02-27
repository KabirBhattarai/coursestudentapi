namespace efcore.Dtos;

public class StudentCourseResponseDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int CourseId { get; set; }
    public string CourseName { get; set; }
}