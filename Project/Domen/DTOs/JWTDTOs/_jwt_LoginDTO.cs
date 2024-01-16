using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DTOs.JWTDTOs
{
    public class _jwt_LoginDTO
    {
        [Required(ErrorMessage = "Data Annotation Error: The _jwt_Username field is required")]
        public string? _jwt_Username { get; set; }

        [Required(ErrorMessage = "Data Annotation Error: The _jwt_Password field is required")]
        public string? _jwt_Password { get; set; }
    }
}
