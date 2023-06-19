using TesteSNSYS.Domain.Entities;
using TesteSNSYS.Domain.Interfaces.Repositories;
using TesteSNSYS.Domain.Interfaces.Service;

namespace TesteSNSYS.Domain.Service
{
    public class CustomerBase : ServiceBase<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerBase(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
    }
}
