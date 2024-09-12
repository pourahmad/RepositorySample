using EntityFrameWorkSample.Entities;
using EntityFrameWorkSample.Services.Repository;

namespace EntityFrameWorkSample.Services.EnrollmentServices;

public interface IEnrollmentRepository : IAsyncRepository<Enrollment>
{
}
