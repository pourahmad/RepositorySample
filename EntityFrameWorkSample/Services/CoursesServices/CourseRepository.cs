using EntityFrameWorkSample.Data;
using EntityFrameWorkSample.Entities;
using EntityFrameWorkSample.Services.Repository;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkSample.Services.CoursesServices;

public class CourseRepository(AppSampleDbContext context): 
    BaseRapository<Course>(context), ICourseRepository
{
    public override async Task<Course?> GetByIdAsync(int id)
    {
        var course = await context
            .Set<Course>()
            .Include(i => i.enrollments)
            .FirstOrDefaultAsync();

        return course;
    }
}
