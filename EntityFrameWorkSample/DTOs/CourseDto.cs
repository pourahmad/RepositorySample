namespace EntityFrameWorkSample.DTOs;
public class CourseDto: CourseUpdateDto
{
    public IList<EnrollmentsDto> Enrollments { get; set; }
}
