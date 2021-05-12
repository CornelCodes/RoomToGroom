using API.Data;
using API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingAPI.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private GroomingDbContext dbContext;
        public CustomerController(GroomingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await dbContext.Customers.ToListAsync<Customer>();
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/[controller]/[action]/id")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await dbContext.Customers.SingleAsync(c => c.CustomerID == id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Customer customer)
        {
            //Creation working - Fix enums

            var state = ModelState;

            var output = new Customer()
            {
                GroomerID = 1,
                Name = customer.Name,
                Surname = customer.Surname,
                Email = customer.Email,
                ContactNumber = customer.ContactNumber,
                CustomerSince = DateTime.Now,
                GroomDay = customer.GroomDay,
                GroomFrequency = customer.GroomFrequency,
                Pets = null
            };
            await dbContext.Customers.AddAsync(output);
            var result = await dbContext.SaveChangesAsync();
            return Ok(result);
        }
    }
}
