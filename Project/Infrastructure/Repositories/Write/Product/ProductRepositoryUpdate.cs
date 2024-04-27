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
    public class ProductRepositoryUpdate : IProductRepositoryUpdate
    {
        private readonly IProductRepositoryResponse Response;

        public ProductRepositoryUpdate(IProductRepositoryResponse response)
        {
            Response = response;
        }

        public async Task UpdateProduct(Guid OldProductBarcode, Guid? NewProductBarcode, double? NewProductPrice)
        {
            ProductWriteModel product = await Response.ResponseProduct(OldProductBarcode);

            if (NewProductBarcode.HasValue)
            {
                product.Barcode = NewProductBarcode.Value;
            }

            if (NewProductPrice.HasValue)
            {
                product.Price = NewProductPrice.Value;
            }
        
         
        }
    }
}
