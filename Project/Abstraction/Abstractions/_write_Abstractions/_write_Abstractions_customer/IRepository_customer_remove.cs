using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer
{
    public interface IRepository_customer_remove
    {
        Task<_customer_Model_write> _customer_Method_remove(Guid customer_PIN);
    }
}
