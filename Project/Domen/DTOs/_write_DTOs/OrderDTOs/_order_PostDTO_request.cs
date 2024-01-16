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
    public  class _order_PostDTO_request:IRequest<_order_PostDTO_respons>
    {
        [Required(ErrorMessage = "Data Annotation Error: The _order_Code field is required")]
        public Guid _order_Code { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The _order_customer_PIN field is required")]
        public Guid _order_customer_PIN { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The _order_product_Barcode field is required")]
        public Guid _order_product_Barcode { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The _order_Deedline field is required")]
        public DateTime _order_Deedline { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The _order_CreatedTime field is required")]
        public DateTime _order_CreatedTime { get; set; }

    }
}
