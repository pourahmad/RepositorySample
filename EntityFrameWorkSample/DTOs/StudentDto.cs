namespace EntityFrameWorkSample.DTOs;
public class StudentDto: StudentUpdateDto
{
    public IList<EnrollmentsDto> Enrollments { get; set; }
}
