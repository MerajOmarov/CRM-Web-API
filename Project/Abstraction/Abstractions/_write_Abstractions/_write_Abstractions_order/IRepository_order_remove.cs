using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions._write_Abstractions._write_Abstractions_order
{
    public interface IRepository_order_remove
    {
        Task<_order_Model_write> _order_Method_remove(Guid order_Code);
    }
}
