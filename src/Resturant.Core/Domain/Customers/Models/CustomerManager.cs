using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Resturant.Models;
using Resturant.Models.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Domain.Customers.Models
{
    public class CustomerManager :  ICustomerManager
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerManager(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
    }
}
