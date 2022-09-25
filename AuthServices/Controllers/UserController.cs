using AuthServiceBussiness.Concrete;
using AuthServices.Models.Request;
using AuthServicesDAL.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AuthManager _authManager;
        private readonly ILogger<UserController> _logger;

        public IConfiguration _config;

        public UserController(IConfiguration config, ILogger<UserController> logger, AuthManager authManager)
        {
            _logger = logger;
            _config = config;
            _authManager = authManager;
        }
        [HttpPost]
        [Route("Login")]
        public  IActionResult Login([FromBody] LoginRequest request)
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
            var loginUser = _authManager.Login(request);

            if (loginUser != null)
            {
                var token = Generate(loginUser);
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

        //private User Authenticate(LoginRequest userLogin)
        //{
        //    var currentUser = _authManager.Users.FirstOrDefault(x => x.Email.ToLower() == userLogin.Email.ToLower() && x.Password == userLogin.Password);
        //    //var currentUser = UserConstants.Users.FirstOrDefault(x => x.Email.ToLower() == userLogin.Email.ToLower() && x.Password == userLogin.Password);
        //    if (currentUser != null)
        //    {
        //        return currentUser;
        //    }
        //    return null;


        //}

        //[HttpPost]
        //[Route("Register")]
        //public async Task<IActionResult> Register([FromBody] LoginRequest request)
        //{
        //    return Ok();
        //}
       
    }
}   
