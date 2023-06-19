using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSNSYS.Domain.Entities;

namespace TesteSNSYS.Application.Interfaces
{
    public interface IUserAppService : IAppServiceBase<Login>
    {
        Task<Login> GetUser(string user, string passWord);
    }
}
