using AutoMapper;
using Domen.DTOs.CommandDTOs.ProductDTOs;
using Domen.DTOs.Write.Product;
using Domen.Models.CommandModels;

namespace Buisness.Mappings.CommandMapping.ProductMapping
{
    public class ProductUpdateDTOWriteMapper:Profile
    {
        public ProductUpdateDTOWriteMapper()
        {
            CreateMap<UpdateProductRequest, ProductWriteModel>();

            CreateMap<ProductWriteModel, UpdateProductResponse>();
        }
    }
}
