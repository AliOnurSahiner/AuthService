using AuthServices.Context;
using AuthServices.Entities;
using AuthServices.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AuthDBContext _context = new AuthDBContext();
        private readonly ILogger<UserController> _logger;

        public IConfiguration _config;

        public UserController(IConfiguration config, ILogger<UserController> logger, AuthDBContext context)
        {
            _logger = logger;
            _config = config;
            _context = context;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            _logger.LogInformation("Privacy Page");
            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex,"This Exception Privacy Page");
            }
            var user = Authenticate(request);

            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }

            return NotFound("User not found");


        }

        private object Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new []
            {

                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Role)

            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],_config["Jwt:Audience"],claims
                ,expires:DateTime.Now.AddMinutes(15),signingCredentials:credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(LoginRequest userLogin)
        {
            var currentUser = _context.Users.FirstOrDefault(x => x.Email.ToLower() == userLogin.Email.ToLower() && x.Password == userLogin.Password);
            //var currentUser = UserConstants.Users.FirstOrDefault(x => x.Email.ToLower() == userLogin.Email.ToLower() && x.Password == userLogin.Password);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;


        }

        //[HttpPost]
        //[Route("Register")]
        //public async Task<IActionResult> Register([FromBody] LoginRequest request)
        //{
        //    return Ok();
        //}
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return Ok(JsonConvert.SerializeObject(_context.Users.ToList()));
        }

    }
}   
