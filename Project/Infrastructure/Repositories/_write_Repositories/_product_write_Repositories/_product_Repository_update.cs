using Abstraction.Abstractions._write_Abstractions._write_Abstractions_product;
using Domen.Models.CommandModels;
using FluentValidation.Validators;
using Infrastructure.DataContexts.CommandDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CommandRepositories.ProductRepository
{
    public class _product_Repository_update : IRepository_product_update
    {
        private readonly _DbContext_write DbContext_write;
        private readonly IRepository_product_respons product_Repository_respons;

        public _product_Repository_update(_DbContext_write dbContext_write, IRepository_product_respons product_Repository_respons)
        {
            DbContext_write = dbContext_write;
            this.product_Repository_respons = product_Repository_respons;
        }

        public async Task _product_Method_update(Guid product_oldBarcode, Guid? product_newpBarcode, double? product_newPrice)
        {
           _product_Model_write product = await product_Repository_respons._product_Method_respons(product_oldBarcode);
            if (product_newpBarcode.HasValue)
            {
                product._product_Barcode = product_newpBarcode.Value;
            }
            if (product_newPrice.HasValue)
            {
                product._product_Price = product_newPrice.Value;
            }
        
         
        }
    }
}
