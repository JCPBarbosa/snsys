using Microsoft.EntityFrameworkCore;
using TesteSNSYS.Domain.Entities;

namespace TesteSNSYS.Infra.Data.Context
{
    public class PostGresContext : DbContext
    {
        public PostGresContext()
        {

        }

        public PostGresContext(DbContextOptions<PostGresContext> options) : base(options)
        {

        }

        public DbSet<Login> Login { get; set; }
        public DbSet<Customer> Customer { get; set; }
    }
}
