using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer
{
    public interface ICustomerRepositoryPost
    {
        Task PostCustomer(CustomerModelwrite customer_model_write);
    }
}
