using Abstraction.Abstractions._write_Abstractions._write_Abstractions_product;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CommandRepositories.ProductRepository
{
    public class _product_Repository_respons : IRepository_product_respons
    {
        private readonly _DbContext_write DbContext_write;

        public _product_Repository_respons(_DbContext_write dbContext_write)
        {
            DbContext_write = dbContext_write;
        }

        public async Task<_product_Model_write> _product_Method_respons(Guid product_Barcode)
        {
            _product_Model_write product= await DbContext_write.All_products_Model_write.SingleOrDefaultAsync(x => x._product_Barcode == product_Barcode);
            return product;
        }

    }
}
