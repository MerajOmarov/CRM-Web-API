using Domen.DTOs.CommandDTOs.CustomerDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DTOs.Command.Customer
{
    public  class UpdateCustomerRequest:IRequest<UpdateCustomerResponse>
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;
    }
}
