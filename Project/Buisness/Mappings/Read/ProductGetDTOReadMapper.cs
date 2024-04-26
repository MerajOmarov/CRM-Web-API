using AutoMapper;
using Domen.DTOs.QueryDTO;
using Domen.Models.CommandModels;
using Domen.Models.QueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mappings.Read
{
    public  class ProductGetDTOReadMapper:Profile
    {
        public ProductGetDTOReadMapper()
        {
            CreateMap<ProductModelread, ProductGetDTO>();
        }
    }
}
