using AutoMapper;
using Buisness.DTOs.Command.Order;
using Buisness.DTOs.CommandDTOs.Order;
using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mappings.Write.Order
{
    public class OrderPostDTOWriteMapper : Profile
    {
        public OrderPostDTOWriteMapper()
        {
            CreateMap<OrderPostDTOrequest, OrderWriteModel>();

            CreateMap<OrderWriteModel, OrderPostDTOresponse>();
        }
    }
}
