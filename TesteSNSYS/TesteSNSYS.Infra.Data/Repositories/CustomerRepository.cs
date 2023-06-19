using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSNSYS.Domain.Entities;
using TesteSNSYS.Domain.Interfaces.Repositories;
using TesteSNSYS.Infra.Data.Context;

namespace TesteSNSYS.Infra.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly PostGresContext _postGresContext;

        public CustomerRepository(PostGresContext postGresContext): base(postGresContext)
        {
            _postGresContext = postGresContext;
        }
    }
}
