using EntityFrameWorkSample.Entities;
using EntityFrameWorkSample.Services.Repository;

namespace EntityFrameWorkSample.Services.CoursesServices;

public interface ICourseRepository : IAsyncRepository<Course> 
{
}
