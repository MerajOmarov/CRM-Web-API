using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer
{
    public interface ICustomerRepositoryResponse
    {
        Task<CustomerModelwrite> ResponseCustomer(Guid _customer_PIN);
    }
}
