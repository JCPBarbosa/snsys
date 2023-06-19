using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSNSYS.Application.Interfaces;
using TesteSNSYS.Domain.Entities;
using TesteSNSYS.Domain.Interfaces.Service;

namespace TesteSNSYS.Application.Service
{
    public class CustomerAppService : AppServiceBase<Customer>, ICustomerAppService
    {
        private readonly ICustomerService _customerService;

        public CustomerAppService(ICustomerService customerService) : base(customerService)
        {
            _customerService = customerService;
        }
    }
}
