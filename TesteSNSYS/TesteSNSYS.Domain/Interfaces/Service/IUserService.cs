using TesteSNSYS.Domain.Entities;

namespace TesteSNSYS.Domain.Interfaces.Service
{
    public interface IUserService : IServiceBase<Login>
    {
        Task<Login> GetUser(string user, string passWord);
    }
}
