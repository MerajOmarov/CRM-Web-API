using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.JWTModels
{
    public class _jwt_ApplicationUser : IdentityUser
    {
        public string _jwt_Name { get; set; }
        public string _jwt_Sername { get; set; }
    }
}
