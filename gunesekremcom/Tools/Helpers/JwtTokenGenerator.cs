using gunesekremcom.CQRS.Results.UserResults;
using gunesekremcom.Models;
using gunesekremcom.Tools.Constants;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace gunesekremcom.Tools.Helpers
{
    public class JwtTokenGenerator
    {
        public static TokenResponseModel GenerateToken(CheckUserQueryResult model)
        {
            var claims = new List<Claim>();


            claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()));

            if (!string.IsNullOrEmpty(model.Name))
                claims.Add(new Claim("Name", model.Name));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: credentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return new TokenResponseModel(handler.WriteToken(jwtSecurityToken), expireDate);
        }
    }
}
