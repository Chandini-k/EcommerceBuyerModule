using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BUYERDBENTITY.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using UserService.Manager;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _iUserManager;
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration configuration;

        public UserController(ILogger<UserController> logger, IUserManager iUserManager, IConfiguration configuration)
        {
            _logger = logger;
            _iUserManager = iUserManager;
            this.configuration = configuration;
        }
        /// <summary>
        /// Register buyer
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Buyer(BuyerRegister buyer)
        {

            _logger.LogInformation("Register");
            if (buyer is null)
            {
                return BadRequest("Buyer already exists");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _logger.LogInformation("Succesfully Registered");
            return Ok(await _iUserManager.BuyerRegister(buyer));

        }
        /// <summary>
        /// Login Buyer
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Login/{username}/{password}")]
        public async Task<IActionResult> BuyerLogin(string username,string password)
        {
            Token token = null;
            _logger.LogInformation("User Login");

            Login login1 = await _iUserManager.BuyerLogin(username,password);
            if (login1 != null)
            {
                token = new Token() { buyerid=login1.buyerId,username=login1.userName,token = GenerateJwtToken(username), message = "Success" };
            }
            else
            {
                token = new Token() { token = null, message = "UnSuccess" };
            }
            _logger.LogInformation($"Welcome{username}");
            return Ok(token);
        }
        private string GenerateJwtToken(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(ClaimTypes.Role,username)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // recommended is 5 min
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtExpireDays"]));
            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}