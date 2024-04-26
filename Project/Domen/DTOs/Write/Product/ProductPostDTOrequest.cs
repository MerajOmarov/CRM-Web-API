using Domen.DTOs.CommandDTOs.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DTOs.CommandDTOs.Product
{
    public  class ProductPostDTOrequest:IRequest<ProductPostDTOresponse>
    {
        [Required(ErrorMessage = "Data Annotation Error: The Name field is required")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The Description field is required")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The Videocard field is required")]
        public string Videocard { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The OperatingSystem field is required")]
        public string OperatingSystem { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The Screen field is required")]
        public string Screen { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The Prosessor field is required")]
        public string Prosessor { get; set; }
      

        [Required(ErrorMessage = "Data Annotation Error: The Price field is required")]
        public double Price { get; set; }

        public string Company { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The Barcode field is required")]
        public Guid Barcode { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The CreatedTime field is required")]
        public DateTime CreatedTime { get; set; }
    }
}
