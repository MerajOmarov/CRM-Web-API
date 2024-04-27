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
    public  class ProductUpdateDTOrequest:IRequest<ProductUpdateDTOresponse>
    {
        [Required(ErrorMessage = "Data Annotation Error: The OldBarcode field is required")]
        public Guid OldBarcode { get; set; }

        [Required(ErrorMessage = "Data Annotation Error: The NewBarcode field is required")]
        public Guid NewBarcode { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The Price field is required")]
        public double NewPrice { get; set; }
    }
}
