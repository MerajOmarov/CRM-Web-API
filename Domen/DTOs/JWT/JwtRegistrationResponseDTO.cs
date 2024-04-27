using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.JWT
{
    public  class JwtRegistrationResponseDTO
    {
        public string Name { get; set; }
        public string Sername { get; set; }
        public Guid Id { get; set; }

    }
}
