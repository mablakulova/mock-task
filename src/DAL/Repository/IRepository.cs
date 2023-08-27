using DAL.Entities;

namespace DAL.Repository;

public interface IRepository<T> where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<T> GetByIdAsync(int id);

    Task AddAsync(T entity);

    Task DeleteAsync(int id);
}
