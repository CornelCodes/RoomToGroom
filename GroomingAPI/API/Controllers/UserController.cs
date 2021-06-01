using API.Data;
using API.Models;
using GroomingAPI.Models;
using GroomingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private GroomingDbContext _dbContext;
        private IConfiguration _config;
        private IUserService _userService;

        public UserController(GroomingDbContext dbContext, IConfiguration config, IUserService userService)
        {
            _dbContext = dbContext;
            _config = config;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody]LoginModel loginModel) 
        {
            IActionResult response = Unauthorized();
            var userResult = AuthenticateUser(loginModel);

            if(userResult != null)
            {
                _userService.SetUser(userResult);
                var tokenString = GenerateJSONWebToken(userResult);
                response = Ok(new { token = tokenString, user = userResult });
            }

            return response;
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User AuthenticateUser(LoginModel login)
        {
            User userModel = null;

            List<User> users = _dbContext.Users.ToList();

            foreach (var user in users)
            {
                if(user.Email == login.Email && user.Password == login.Password)
                {
                    userModel = user;
                }
            }

            return userModel;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody]RegisterModel registerModel)
        {
            var existingUser = await _dbContext.Users.Where(u => u.Email == registerModel.Email).SingleOrDefaultAsync();

            if (ModelState.IsValid)
            {
                if(existingUser == null)
                {
                    User newUser = new User()
                    {
                        Name = registerModel.Name,
                        Email = registerModel.Email,
                        Password = registerModel.Password,
                        RegisterDate = DateTime.Now,
                        LastLogin = DateTime.Now,
                        Customers = null
                    };

                    await _dbContext.Users.AddAsync(newUser);

                    try
                    {
                        await _dbContext.SaveChangesAsync();
                        return Ok();
                    }
                    catch (Exception)
                    {
                        return Conflict();
                    }

                }
                else
                {
                    return Conflict(existingUser);
                }
            }
            else
            {
                return Conflict(ModelState);
            }

        }
    }
}
