using Abstraction;
using Domen.DTOs.JWT;
using Domen.JWTModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure
{
    public class JwtRepositoryauth : IJwtAuth
    {
        private readonly UserManager<JwtApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public JwtRepositoryauth(UserManager<JwtApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<(int, string)> JwtLoginAsync(JwtLoginDTO Login, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(Login.Username); 

            if (user == null) 
                return (0, "Invalid username");
            if (!await _userManager.CheckPasswordAsync(user, Login.Password))
                return (0, "Invalid password");

            var userRoles = await _userManager.GetRolesAsync(user);

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

        public async Task<(int, string)> JwtRegistrationAsync(JwtRegistrationRequestDTO Request, string role, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByNameAsync(Request.Username);

            if (userExists != null)
                return (0, "User already exists");

            JwtApplicationUser user = new JwtApplicationUser()
            {
                Email = Request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = Request.Username,
                Name = Request.Name
            };

            var createUserResult = await _userManager.CreateAsync(user, Request.Password);

            if (!createUserResult.Succeeded)
                return (0, "User creation failed! Please check user details and try again.");

            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));

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
