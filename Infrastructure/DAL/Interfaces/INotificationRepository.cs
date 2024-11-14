using FinalTestDomain.Models;

namespace Infrastructure.DAL.Interfaces;

public interface INotificationRepository
{
    Task<Notification> AddAsync(Notification notification);
    Task<Notification> GetByIdAsync(Guid id);
    Task<IEnumerable<Notification>> GetAllAsync();
    Task UpdateAsync(Notification notification);
    Task DeleteAsync(Guid id);
}