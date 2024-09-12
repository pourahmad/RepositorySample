using EntityFrameWorkSample.Data;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkSample.Services.Repository;

public class BaseRapository<T>(AppSampleDbContext context) : IAsyncRepository<T> where T : class
{
    private readonly AppSampleDbContext _context = context;

    public virtual async Task<T?> GetByIdAsync(int id)
        => await _context.Set<T>().FindAsync(id);

    public virtual async Task<IReadOnlyCollection<T>> GetAllAsync(int pageNumber, int pageSize)
        => await _context.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

    public virtual async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}
