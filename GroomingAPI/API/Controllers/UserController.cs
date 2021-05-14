using API.Data;
using API.Models;
using GroomingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private GroomingDbContext dbContext;
        public UserController(GroomingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody]LoginModel login) 
        {
            var state = ModelState;
            var users = await dbContext.Users.ToListAsync();
            User result = null;
            foreach (var user in users)
            {
                if (user.Email == login.Email && user.Password == login.Password)
                {
                    result = user;
                }
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody]User user)
        {
            var state = ModelState;
            var result = await dbContext.Users.AddAsync(new User()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                RegisterDate = DateTime.Now,
                LastLogin = DateTime.Now,
                Customers = null
            });

            return Ok(result);
        }
    }
}
