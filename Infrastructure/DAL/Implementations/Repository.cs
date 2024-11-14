using System.Linq.Expressions;
using Infrastructure.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Implementations;

public abstract class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationContext _context;

    public Repository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        try
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;

    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<T> GetWithIncludesAsync(Guid id, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>();

        foreach (var include in includes) query = query.Include(include);

        return await query.FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
    }

    public async Task<IEnumerable<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>();

        foreach (var include in includes) query = query.Include(include);

        return await query.ToListAsync();
    }

    public async Task AddWithIncludesAsync(T entity, params Expression<Func<T, object>>[] includes)
    {
        foreach (var include in includes) _context.Entry(entity).Reference(include).Load();
        await AddAsync(entity);
    }

    public async Task<bool> UpdateWithIncludesAsync(T entity, params Expression<Func<T, object>>[] includes)
    {
        try
        {
            foreach (var include in includes) _context.Entry(entity).Reference(include).Load();
            await UpdateAsync(entity);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
}