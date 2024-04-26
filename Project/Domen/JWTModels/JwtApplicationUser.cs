using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.JWTModels
{
    public class JwtApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Sername { get; set; }
    }
}
