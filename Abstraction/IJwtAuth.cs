﻿
using Domen.DTOs.JWT;

namespace Abstraction
{
    public  interface IJwtAuth
    {
        Task<(int, string)> JwtRegistrationAsync(JwtRegistrationRequestDTO registration,
                                                 string role,
                                                 CancellationToken cancellationToken);
        Task<(int, string)> JwtLoginAsync(JwtLoginDTO Login,
                                          CancellationToken cancellationToken);
    }
}
