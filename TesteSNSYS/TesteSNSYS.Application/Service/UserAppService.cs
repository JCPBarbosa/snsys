using TesteSNSYS.Application.Interfaces;
using TesteSNSYS.Domain.Entities;
using TesteSNSYS.Domain.Interfaces.Service;

namespace TesteSNSYS.Application.Service
{
    public class UserAppService : AppServiceBase<Login>, IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        public async Task<Login> GetUser(string user, string passWord)
        {
            return await _userService.GetUser(user, passWord);
        }
    }
}
