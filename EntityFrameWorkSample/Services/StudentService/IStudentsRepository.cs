using EntityFrameWorkSample.Entities;
using EntityFrameWorkSample.Services.Repository;

namespace EntityFrameWorkSample.Services.StudentService;

public interface IStudentsRepository : IAsyncRepository<Student>
{
}
