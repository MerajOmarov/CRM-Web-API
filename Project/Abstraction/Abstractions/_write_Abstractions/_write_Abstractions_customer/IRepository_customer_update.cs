using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer
{
    public interface IRepository_customer_update
    {
        Task _customer_Method_update(Guid customer_oldPIN, Guid customer_newPIN);
    }
}
