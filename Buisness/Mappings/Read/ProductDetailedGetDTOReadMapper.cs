using AutoMapper;
using Domen.DTOs._read_DTOs;
using Domen.Models.QueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mappings.Read
{
    public  class ProductDetailedGetDTOReadMapper:Profile
    {
        public ProductDetailedGetDTOReadMapper()
        {
            CreateMap<ProductReadModel,ProductDetailedReadDTO>();
        }
    }
}
