using Microsoft.EntityFrameworkCore;
using TesteSNSYS.Domain.Entities;
using TesteSNSYS.Domain.Interfaces.Repositories;
using TesteSNSYS.Infra.Data.Context;

namespace TesteSNSYS.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<Login>, IUserRepository
    {
        private readonly PostGresContext _context;

        public UserRepository(PostGresContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Login> GetUser(string user, string passWord)
        {
            return await _context.Login.Where(x => x.User.ToLower().Equals(user.ToLower()) && x.Password.Equals(passWord)).FirstOrDefaultAsync();
        }
    }
}
