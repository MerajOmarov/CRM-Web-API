using AutoMapper;
using Buisness.DTOs.Command.Product;
using Buisness.DTOs.CommandDTOs.Product;
using Domen.DTOs.CommandDTOs.ProductDTOs;
using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mappings.CommandMapping.ProductMapping
{
    public class ProductUpdateDTOWriteMapper:Profile
    {
        public ProductUpdateDTOWriteMapper()
        {
            CreateMap<ProductRequestUpdateDTO, ProductWriteModel>();

            CreateMap<ProductWriteModel, ProductResponseUpdateDTO>();
        }
    }
}
