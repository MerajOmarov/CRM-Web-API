using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DTOs.JWTDTOs
{
    public class _jwt_RegistrationDTO_Request
    {
        [Required(ErrorMessage = "Data Annotation Error: The _jwt_Username field is required")]
        public string _jwt_Username { get; set; }

        [Required(ErrorMessage = "Data Annotation Error: The _jwt_Name field is required")]
        public string _jwt_Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Data Annotation Error: The _jwt_Email field is required")]
        public string _jwt_Email { get; set; }

        [Required(ErrorMessage = "Data Annotation Error: The _jwt_Password field  is required")]
        public string _jwt_Password { get; set; }
    }
}
