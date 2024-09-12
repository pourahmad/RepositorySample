using EntityFrameWorkSample.Entities;

namespace EntityFrameWorkSample.Models;

public class EnrollmentVM
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime EnrollmentDate { get; set; }

    public StudentVM Student { get; set; } = new StudentVM();
    public CourseVM Course { get; set; } = new CourseVM();
}
