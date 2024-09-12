using EntityFrameWorkSample.Data;
using EntityFrameWorkSample.Entities;
using EntityFrameWorkSample.Models;
using EntityFrameWorkSample.Services.Repository;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkSample.Services.EnrollmentServices;

public class  EnrollmentRepository(AppSampleDbContext context):
    BaseRapository<Enrollment>(context), IEnrollmentRepository
{
    public override async Task<IReadOnlyCollection<Enrollment>> GetAllAsync(int pageNumber, int pageSize)
    {
        var result = await context
            .Set<Enrollment>()
            .Include(i => i.Course)
            .Include(i => i.Student)
            .ToListAsync();

        return result;        
    }
}
