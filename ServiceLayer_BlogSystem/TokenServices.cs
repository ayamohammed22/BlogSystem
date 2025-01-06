using CoreLayer_BlogSystem.Entities.Identity;
using CoreLayer_BlogSystem.Services;
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

namespace ServiceLayer_BlogSystem
{
    public class TokenServices : ITokenServices
    {
        private readonly IConfiguration _configuration;

        public TokenServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> CreateTokenasync(AppUser user, UserManager<AppUser> userManager)
        {
            var ClaimAuth = new List<Claim>()
            {
               new Claim (ClaimTypes.Name , user.UserName), 
               new Claim (ClaimTypes.Email , user.Email)
             };
            var UserRole = await userManager.GetRolesAsync(user);
            foreach (var Role in UserRole)
            {
                ClaimAuth.Add(new Claim( ClaimTypes.Role, Role));
            }

            var AuthKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var Token = new JwtSecurityToken (
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(double.Parse(_configuration["JWT:DurationInDays"])),
                claims: ClaimAuth,
                signingCredentials: new SigningCredentials(AuthKey, SecurityAlgorithms.HmacSha256Signature)
             );

            return new JwtSecurityTokenHandler ().WriteToken(Token);
           
        }
    }
}
