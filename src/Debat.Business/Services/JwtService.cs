using Debat.Core.Application.Services;
using Debat.Core.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Debat.Business.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;

        public JwtService(IConfiguration configuration,
                          UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public string GenerateToken(AppUser user)
        {
            List<Claim> claims = GetUserClaims(user);

            SymmetricSecurityKey symmetricSecurityKey = GetSymmetricSecurityKey();

            SigningCredentials signingCredentials = GetSignInCredentials(symmetricSecurityKey);


            JwtSecurityToken token = new JwtSecurityToken(issuer: _configuration.GetSection("Jwt:issuer").Value,
                                                          audience: _configuration.GetSection("Jwt:audience").Value,
                                                          claims: claims,
                                                          expires: DateTime.UtcNow.AddDays(3),
                                                          signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private List<Claim> GetUserClaims(AppUser user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };

            IList<string> userRoles = _userManager.GetRolesAsync(user).Result;

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:securityKey").Value));
        }

        private SigningCredentials GetSignInCredentials(SymmetricSecurityKey symmetricSecurityKey)
        {
            return new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        }
    }
}
