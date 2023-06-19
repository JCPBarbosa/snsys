using System.Security.Cryptography.X509Certificates;
using TesteSNSYS.Domain.Entities;
using TesteSNSYS.Domain.Interfaces.Repositories;
using TesteSNSYS.Domain.Interfaces.Service;

namespace TesteSNSYS.Domain.Service
{
    public class UserBase : ServiceBase<Login>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserBase(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Login> GetUser(string user, string passWord)
        {
            return await _userRepository.GetUser(user, passWord);
        }
    }
}
