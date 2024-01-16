using Abstraction.Abstractions._write_Abstractions._write_Abstractions_product;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CommandRepositories.ProductRepository
{
    public class _product_Repository_remove : IRepository_product_remove
    {
        private readonly _DbContext_write DbContext_write;
        private readonly IRepository_product_respons product_Repository_respons;

        public _product_Repository_remove(_DbContext_write dbContext_write, IRepository_product_respons product_Repository_respons)
        {
            DbContext_write = dbContext_write;
            this.product_Repository_respons = product_Repository_respons;
        }

        public async Task<_product_Model_write> _product_Method_remove(Guid product_Barcode)
        {
            _product_Model_write product = await product_Repository_respons._product_Method_respons(product_Barcode);
            DbContext_write.All_products_Model_write.Remove(product);
            return product;
        }
    }
}
