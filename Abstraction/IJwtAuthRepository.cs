
using Domen.DTOs.JWT;

namespace Abstraction
{
    public  interface IJwtAuthRepository
    {
        Task<(int, string)> JwtRegistrationAsync(JwtRegistrationRequestDTO registration,
                                                 string role,
                                                 CancellationToken cancellationToken);
        Task<(int, string)> JwtLoginAsync(JwtLoginDTO Login,
                                          CancellationToken cancellationToken);
    }
}
