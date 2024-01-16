using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.CommandDTOs.ProductDTOs
{
    public  class _product_DeleteDTO_request:IRequest<_product_DeleteDTO_respons>
    {
        [Required(ErrorMessage = "Data Annotation Error: The _product_Barcode field is required")]
        public Guid _product_Barcode { get; set; }
    }
}
