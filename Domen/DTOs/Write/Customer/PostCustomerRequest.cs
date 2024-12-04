using Buisness.DTOs.CommandDTOs.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DTOs.Command.Customer
{
    public  class PostCustomerRequest:IRequest<PostCustomerResponse>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public Guid PIN { get; set; }
    }
}
