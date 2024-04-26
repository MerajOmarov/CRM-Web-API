using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.CommandDTOs.ProductDTOs
{
    public  class ProductDeleteDTOrequest:IRequest<ProductDeleteDTOresponse>
    {
        [Required(ErrorMessage = "Data Annotation Error: The Barcode field is required")]
        public Guid Barcode { get; set; }
    }
}
