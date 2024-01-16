using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions._write_Abstractions._write_Abstractions_product
{
    public interface IRepository_product_update
    {
        Task _product_Method_update(Guid product_oldBarcode, Guid? product_newpBarcode, double? product_newPrice);
    }
}
