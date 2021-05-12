using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class GroomerController : Controller
    {
        private GroomingDbContext dbContext;
        public GroomerController(GroomingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string email, string password)
        {
            var state = ModelState;
            var groomers = await dbContext.Groomers.ToListAsync();
            Groomer result = null;
            foreach (var user in groomers)
            {
                if(user.Email == email && user.Password == password)
                {
                    result = user;
                }
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Groomer groomer)
        {
            var result = dbContext.Groomers.Add(groomer);
            return Ok(result);
        }
    }
}
