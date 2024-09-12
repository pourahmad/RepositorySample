using EntityFrameWorkSample.Data;
using EntityFrameWorkSample.Entities;
using EntityFrameWorkSample.Services.Repository;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkSample.Services.StudentService;

public class StudentRepository(AppSampleDbContext context) : 
    BaseRapository<Student>(context), IStudentsRepository
{
    public override async Task<Student?> GetByIdAsync(int id)
    {
        var student = await context
            .Set<Student>()
            .Include(i => i.enrollments)
            .FirstOrDefaultAsync();

        return student; 
    }
}
