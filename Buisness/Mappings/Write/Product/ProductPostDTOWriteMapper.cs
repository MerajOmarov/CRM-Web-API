using AutoMapper;
using Buisness.DTOs.CommandDTOs.Product;
using Domen.DTOs.CommandDTOs.ProductDTOs;
using Domen.Models.CommandModels;

namespace Buisness.Mappings.CommandMapping.ProductMapping
{
    public class ProductPostDTOWriteMapper : Profile
    {
        public ProductPostDTOWriteMapper()
        {
            CreateMap<PostProductRequest, ProductWriteModel>();

            CreateMap<ProductWriteModel, PostProductResponse>();
        }
    }
}
