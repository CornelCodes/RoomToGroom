using API.Data;
using API.Models;
using GroomingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingAPI.Controllers
{
    [Authorize]
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private GroomingDbContext dbContext;
        private IUserService _userService;
        public CustomerController(GroomingDbContext dbContext, IUserService userService)
        {
            this.dbContext = dbContext;
            _userService = userService;
        }

        //Get all customers
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            //Get all the customers that match the current user Id
            var result = await dbContext.Customers.Where(c => c.UserId == _userService.GetUserId()).ToListAsync();
            return Ok(result);
        }

        //Get by CustomerId
        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await dbContext.Customers.SingleAsync(c => c.CustomerId == id);
            return Ok(result);
        }

        //Update customer
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody]Customer customer)
        {
            var customerEntity = await dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == customer.CustomerId);

            if(customerEntity != null)
            {
                customerEntity.Name = customer.Name;
                customerEntity.Surname = customer.Surname;
                customerEntity.Email = customer.Email;
                customerEntity.ContactNumber = customer.ContactNumber;
                customerEntity.GroomDay = customer.GroomDay;
                customerEntity.GroomFrequency = customer.GroomFrequency;
                await dbContext.SaveChangesAsync();
            }

            return Ok(customerEntity);
        }

        //Delete customer
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long customerId)
        {
            var state = ModelState;

            var result = await dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
            if(result != null)
            {
                dbContext.Customers.Remove(result);
                await dbContext.SaveChangesAsync();
            }

            return Ok(result);
        }

        //Create customer
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Customer customer)
        {
            var state = ModelState;

            if(_userService.GetUserId() != -1)
            {
                var output = new Customer()
                {
                    UserId = _userService.GetUserId(),
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
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
