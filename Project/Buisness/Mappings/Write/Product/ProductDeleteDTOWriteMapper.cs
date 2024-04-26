using AutoMapper;
using Domen.DTOs.CommandDTOs.ProductDTOs;
using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mappings.CommandMapping.ProductMapping
{
    public  class ProductDeleteDTOWriteMapper:Profile
    {
        public ProductDeleteDTOWriteMapper()
        {
            CreateMap<ProductDeleteDTOrequest, ProductModelwrite>();

            CreateMap<ProductModelwrite, ProductDeleteDTOresponse>();
        }
    }
}
