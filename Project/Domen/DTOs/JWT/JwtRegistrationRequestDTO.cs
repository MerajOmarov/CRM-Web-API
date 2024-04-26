using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.JWT
{
    public class JwtRegistrationRequestDTO
    {
        [Required(ErrorMessage = "Data Annotation Error: The Username field is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Data Annotation Error: The Name field is required")]
        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Data Annotation Error: The Email field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Data Annotation Error: The Password field  is required")]
        public string Password { get; set; }
    }
}
