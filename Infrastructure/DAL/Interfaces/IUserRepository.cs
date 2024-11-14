using FinalTestDomain.Models;

namespace Infrastructure.DAL.Interfaces;

public interface IUserRepository : IRepository<User>
{

    public  Task<List<User>> FindUsersByIdsAsync(List<Guid> userIds);

}