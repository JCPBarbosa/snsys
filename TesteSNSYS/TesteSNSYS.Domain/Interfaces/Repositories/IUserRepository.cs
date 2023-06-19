using TesteSNSYS.Domain.Entities;

namespace TesteSNSYS.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<Login>
    {
        Task<Login> GetUser(string user, string passWord);
    }
}
