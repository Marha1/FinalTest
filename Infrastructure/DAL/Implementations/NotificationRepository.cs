using FinalTestDomain.Models;
using Infrastructure.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Implementations;

public class NotificationRepository : INotificationRepository
{
    private readonly ApplicationContext _context;

    public NotificationRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Notification> AddAsync(Notification notification)
    {
        await _context.Notifications.AddAsync(notification);
        await _context.SaveChangesAsync();
        return notification;
    }

    public async Task<Notification> GetByIdAsync(Guid id)
    {
        return await _context.Notifications.FindAsync(id);
    }

    public async Task<IEnumerable<Notification>> GetAllAsync()
    {
        return await _context.Notifications.ToListAsync();
    }

    public async Task UpdateAsync(Notification notification)
    {
        _context.Notifications.Update(notification);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var notification = await _context.Notifications.FindAsync(id);
        if (notification != null)
        {
            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
        }
    }
}