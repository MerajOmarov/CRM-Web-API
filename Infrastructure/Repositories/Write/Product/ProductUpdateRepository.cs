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
    public class ProductUpdateRepository : IProductUpdateRepository
    {
        private readonly IProductResponseRepository _response;

        public ProductUpdateRepository(IProductResponseRepository response)
        {
            _response = response;
        }

        public async Task UpdateProduct(Guid oldProductBarcode, Guid? newProductBarcode, double? newProductPrice)
        {
            ProductWriteModel product = await _response.ResponseProduct(oldProductBarcode);

            if (newProductBarcode.HasValue)
                product.Barcode = newProductBarcode.Value;

            if (newProductPrice.HasValue)
                product.Price = newProductPrice.Value;
        }
    }
}
