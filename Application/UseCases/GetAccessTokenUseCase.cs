using ErpSecurity.Domain.Models;
using ErpSecurity.Domain.Ports.In.Usecases;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ErpSecurity.Application.Usecases
{
    public class GetAccessTokenUseCase : IGetAccessTokenUseCase
    {

        public GetAccessTokenUseCase()
        {
        }

        public string Execute(InputGetAccessToken value)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(value.Key);
            var durationInMinutes = value.DurationTokenInMinutes;

            var userIdClaim = new Claim(ClaimTypes.NameIdentifier, value.User.Id.ToString());
            var roleClaims = value.User.UserRoles
                .Select(userRole => new Claim(ClaimTypes.Role, userRole.Role.Code.ToString()))
                .ToArray();

            var claims = new[] { userIdClaim }.Concat(roleClaims).ToArray();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(durationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
