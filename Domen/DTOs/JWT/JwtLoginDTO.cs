using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.JWT
{
    public class JwtLoginDTO
    {
        [Required(ErrorMessage = "Data Annotation Error: The Username field is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Data Annotation Error: The Password field is required")]
        public string? Password { get; set; }
    }
}
