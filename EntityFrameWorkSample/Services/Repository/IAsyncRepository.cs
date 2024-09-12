namespace EntityFrameWorkSample.Services.Repository;

public interface IAsyncRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IReadOnlyCollection<T>> GetAllAsync(int pageNumber, int pageSize);

    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
