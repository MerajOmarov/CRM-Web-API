using Buisness.DTOs.CommandDTOs.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DTOs.Command.Order
{
    public  class OrderRequestPostDTO:IRequest<OrderResponsePostDTO>
    {
        [Required(ErrorMessage = "Data Annotation Error: The Code field is required")]
        public Guid Code { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The CustomerPIN field is required")]
        public Guid CustomerPIN { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The ProductBarcode field is required")]
        public Guid ProductBarcode { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The Deedline field is required")]
        public DateTime Deedline { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The CreatedTime field is required")]
        public DateTime CreatedTime { get; set; }

    }
}
