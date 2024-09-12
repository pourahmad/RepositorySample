namespace EntityFrameWorkSample.Entities;

public class Student
{
    public int Id {  get; set; }  
    public string Name { get; set; }
    public ICollection<Enrollment> enrollments { get; set; }
}