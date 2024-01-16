using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions._write_Abstractions._write_Abstractions_order
{
    public interface IRepository_order_update
    {
        Task _order_Method_update(Guid order_oldCode, Guid order_newCode, DateTime order_newDeedline);
    }
}
