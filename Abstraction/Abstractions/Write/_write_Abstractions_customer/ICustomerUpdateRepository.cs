using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer
{
    public interface ICustomerUpdateRepository
    {
        Task UpdateCustomer(Guid customer_oldPIN, Guid customer_newPIN);
    }
}
