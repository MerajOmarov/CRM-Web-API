using AutoMapper;
using Buisness.DTOs.Command.Customer;
using Buisness.DTOs.CommandDTOs.Customer;
using Domen.DTOs.CommandDTOs.OrderDTOs;
using Domen.DTOs.Write.Order;
using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mappings.Write.Order
{
    public class OrderDeleteDTOWriteMapper:Profile
    {
        public OrderDeleteDTOWriteMapper()
        {
            CreateMap<OrderWriteModel, DeleteOrderResponse>();
        }
    }
}
