using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private GroomingDbContext dbContext;
        public CustomerController(GroomingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await dbContext.Customers.ToListAsync<Customer>();
            return Ok(result);
        }
    }
}
