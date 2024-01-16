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
    public class _product_Repository_post : IRepository_product_post
    {
        private readonly _DbContext_write DbContext_write;

        public _product_Repository_post(_DbContext_write dbContext_write)
        {
            DbContext_write = dbContext_write;
        }

        public async Task _product_Method_post(_product_Model_write product_model_write)
        {
            _product_Model_write? product;
            product = await DbContext_write.All_products_Model_write.SingleOrDefaultAsync(x => x._product_Barcode == product_model_write._product_Barcode);
            if (product != null)
            {
                throw new Exception("ResponsProduct Error: The product with this guid have already exists in database, use different guid");
            }
            await DbContext_write.All_products_Model_write.AddAsync(product_model_write);
        }
    }
}
