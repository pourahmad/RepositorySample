using EntityFrameWorkSample.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkSample.Data;

public class AppSampleDbContext : DbContext
{
    public AppSampleDbContext(DbContextOptions<AppSampleDbContext> options) : base(options)
    {

    }

    DbSet<Student> Students { get; set; }
    DbSet<Course> Courses { get; set; }
    DbSet<Enrollment> Enrollments { get; set; }
}
