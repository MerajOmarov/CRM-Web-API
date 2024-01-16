using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions._write_Abstractions._write_Abstractions_product
{
    public interface IRepository_product_respons
    {
        Task<_product_Model_write> _product_Method_respons(Guid product_Barcode);
    }
}
