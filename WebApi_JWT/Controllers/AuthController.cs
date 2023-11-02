using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi_JWT.Models;
using WebApi_JWT.Repositories;

namespace WebApi_JWT.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        public AuthenticationController(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        [AllowAnonymous]    // Auth Not Including
        [HttpPost("login")]
        public IActionResult Login([FromBody] ApiUser apiUserInfo)
        {
            var apiUser = ApiUserRepository.GetUserByCredentials(apiUserInfo.UserName!, apiUserInfo.Password!);

            if (apiUser == null) return NotFound("User not found!");

            var token = CreateToken(apiUser);

            return Ok(token);
        }

        private string CreateToken(ApiUser apiUser)
        {
            if (_jwtSettings == null) throw new Exception("Jwt settings cannot be null.");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, apiUser.UserName!),
                new Claim(ClaimTypes.Role, apiUser.Role!)
            };

            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}