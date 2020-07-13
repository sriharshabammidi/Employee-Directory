using EmployeeDirectory.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeDirectory.API.Helpers
{
    public static class JwtTokenHelper
    {
        public static string GenerateJSONWebToken(JwtIssuerOptions jwtIssuerOptions, string email, string sessionId = null)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenExpiry = DateTime.Now.AddMinutes(10);
            var _sessionId = sessionId;
            if (sessionId == null)
            {
                _sessionId = Guid.NewGuid().ToString();
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim("ExpiresOn", tokenExpiry.ToString()),
                new Claim("SessionId", _sessionId.ToString()),
            };

            var token = new JwtSecurityToken(
                jwtIssuerOptions.Issuer,
                jwtIssuerOptions.Audience,
                claims,
                expires: tokenExpiry,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
