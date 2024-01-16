using Domen.DTOs.CommandDTOs.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DTOs.Command.Product
{
    public  class _product_UpdateDTO_request:IRequest<_product_UpdateDTO_respons>
    {
        [Required(ErrorMessage = "Data Annotation Error: The _product_oldBarcode field is required")]
        public Guid _product_oldBarcode { get; set; }

        [Required(ErrorMessage = "Data Annotation Error: The _product_newBarcode field is required")]
        public Guid _product_newBarcode { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The _product_Price field is required")]
        public double _product_newPrice { get; set; }
    }
}
