
using Buisness.DTOs.JWTDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public  interface IRepository_jwt_auth
    {
        Task<(int, string)> _jwt_Method_Registeration(_jwt_RegistrationDTO_Request jwt_RegistrationDTO_Request, string role);
        Task<(int, string)> _jwt_Method_Login(_jwt_LoginDTO Jwt_LoginDTO);
    }
}
