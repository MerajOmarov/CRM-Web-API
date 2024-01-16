using Abstraction;
using Buisness.DTOs.JWTDTOs;
using Domen.JWTModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class _jwt_Repository_auth : IRepository_jwt_auth
    {
        private readonly UserManager<_jwt_ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public _jwt_Repository_auth(UserManager<_jwt_ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<(int, string)> _jwt_Method_Login(_jwt_LoginDTO Jwt_LoginDTO)
        {
            var user = await userManager.FindByNameAsync(Jwt_LoginDTO._jwt_Username);
            if (user == null)
                return (0, "Invalid username");
            if (!await userManager.CheckPasswordAsync(user, Jwt_LoginDTO._jwt_Password))
                return (0, "Invalid password");

            var userRoles = await userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            string token = GenerateToken(authClaims);
            return (1, token);
        }

        public async Task<(int, string)> _jwt_Method_Registeration(_jwt_RegistrationDTO_Request jwt_RegistrationDTO_Request, string role)
        {
            var userExists = await userManager.FindByNameAsync(jwt_RegistrationDTO_Request._jwt_Username);
            if (userExists != null)
                return (0, "User already exists");

            _jwt_ApplicationUser user = new _jwt_ApplicationUser()
            {
                Email = jwt_RegistrationDTO_Request._jwt_Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = jwt_RegistrationDTO_Request._jwt_Username,
                _jwt_Name = jwt_RegistrationDTO_Request._jwt_Name
            };
            var createUserResult = await userManager.CreateAsync(user, jwt_RegistrationDTO_Request._jwt_Password);
            if (!createUserResult.Succeeded)
                return (0, "User creation failed! Please check user details and try again.");

            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));

            return (1, "User created successfully!");
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }   

}
