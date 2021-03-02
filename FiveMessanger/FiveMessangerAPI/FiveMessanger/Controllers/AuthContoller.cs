using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using FiveMessanger.Models;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Logging;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace FiveMessanger.Controllers
{
    [EnableCors("reactPolicy")]
    [ApiController]
    public class AuthContoller : ControllerBase
    {
        private readonly FiveMessangerContext _context;
        public AuthContoller(FiveMessangerContext context)
        {
            _context = context;
        }

        [HttpPost("/get_token")]
        public async Task<IActionResult> GetToken([FromBody]User user)
        {

            IdentityModelEventSource.ShowPII = true;

            var identity = await GetIdentity(user.Username, user.Password);
            if (identity == null)
                return BadRequest(new { errorText = "Неправильный логин или пароль!" });

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(
                    AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256
                    )
                );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Ok(response);
        }
        
        [HttpPost("/create_user")]
        public async Task<IActionResult> CreateUser([FromBody]User newUser)
        {

            bool isUserFind = await _context.Users.AnyAsync(u => u.Username == newUser.Username);

            if (isUserFind)
            {
                return BadRequest(new { errorText = "Пользователь с таким логином уже существует" });
            }

            newUser.Password = BCrypt.HashPassword(newUser.Password, BCrypt.GenerateSalt(12));
            await _context.Users.AddAsync(newUser);

            Profile newProfile = new Profile
            {
                User = newUser
            };
            await _context.Profiles.AddAsync(newProfile);

            await _context.SaveChangesAsync();

            return Ok("Success");
        }

        private async Task<ClaimsIdentity> GetIdentity(string username, string password)
        {

            if (username == null || password == null)
                return null;

            User user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
            if (user == null || !(BCrypt.CheckPassword(password, user.Password)))
                return null;
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity
                (
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                                                        ClaimsIdentity.DefaultRoleClaimType)
                );
            return claimsIdentity;
        }
    }
}
