namespace EntityFrameWorkSample.DTOs;

public class EnrollmentDto: EnrollmentUpdeatDto
{
    public StudentsDto Student { get; set; }
    public CoursesDto Course { get; set; }
}
