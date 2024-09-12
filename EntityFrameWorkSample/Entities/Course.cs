namespace EntityFrameWorkSample.Entities;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<Enrollment> enrollments { get; set; }
}
