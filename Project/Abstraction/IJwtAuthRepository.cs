
using Domen.DTOs.JWT;

namespace Abstraction
{
    public  interface IJwtAuthRepository
    {
        Task<(int, string)> JwtRegistration(JwtRegistrationRequestDTO jwt_RegistrationDTO_Request, string role);
        Task<(int, string)> JwtLogin(JwtLoginDTO Jwt_LoginDTO);

        //ackhdlihyvdlihh
    }
}
