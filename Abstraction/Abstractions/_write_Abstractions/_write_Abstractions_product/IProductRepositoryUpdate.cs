using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions._write_Abstractions._write_Abstractions_product
{
    public interface IProductRepositoryUpdate
    {
        Task UpdateProduct(Guid product_oldBarcode, Guid? product_newpBarcode, double? product_newPrice);
    }
}
