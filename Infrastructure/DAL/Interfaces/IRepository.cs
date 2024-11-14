using System.Linq.Expressions;

namespace Infrastructure.DAL.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    // Методы для загрузки вложенных сущностей
    Task<T> GetWithIncludesAsync(Guid id, params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes);
    Task AddWithIncludesAsync(T entity, params Expression<Func<T, object>>[] includes);
    Task<bool> UpdateWithIncludesAsync(T entity, params Expression<Func<T, object>>[] includes);
}