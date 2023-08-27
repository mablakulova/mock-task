using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class Repository<T> : IRepository<T> where T : Entity
{
    private readonly ShortLinkContext linkDbContext;

    public Repository(ShortLinkContext dbContext)
    {
        linkDbContext = dbContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await linkDbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await linkDbContext.Set<T>().SingleOrDefaultAsync(l => l.Id == id);
    }

    public async Task AddAsync(T entity)
    {
        await linkDbContext.Set<T>().AddAsync(entity);
        await linkDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if(entity != null)
        {
            linkDbContext.Remove(entity);
            await linkDbContext.SaveChangesAsync();
        }
    }
}
