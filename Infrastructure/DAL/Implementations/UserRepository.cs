using FinalTestDomain.Models;
using Infrastructure.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Implementations;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    /// <summary>
    ///     Поиск пользователя по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Ответ содержащий информацию о пользователе</returns>
    public async Task<List<User>> FindUsersByIdsAsync(List<Guid> userIds)
    {
        return await _context.Users
            .Where(u => userIds.Contains(u.Id))
            .ToListAsync();
    }
}