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
    public class PetController : Controller
    {
        private GroomingDbContext dbContext;
        private IUserService _userService;

        public PetController(GroomingDbContext dbContext, IUserService userService)
        {
            this.dbContext = dbContext;
            _userService = userService;
        }

        //Get the pet by their PetId
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(long petId)
        {
            var result = await dbContext.Pets.SingleAsync(p => p.PetId == petId);
            return Ok(result);
        }

        //Get all pets
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var customers = await dbContext.Customers.Where(c => c.UserId == _userService.GetUserId()).ToListAsync();
            var pets = new List<Pet>();
            foreach(var customer in customers)
            {
                var customerPets = await dbContext.Pets.Where(p => p.CustomerId == customer.CustomerId).ToListAsync();
                foreach(var pet in customerPets)
                {
                    pets.Add(pet);
                }
            }
            return Ok(pets);
        }

        //Get by CustomerId
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetByCustomerId(long customerId)
        {
            var state = ModelState;

            var result = await dbContext.Pets.Where(p => p.CustomerId == customerId).ToListAsync();
            return Ok(result);
        }

        //Add a pet
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Post(Pet pet)
        {
            var result = dbContext.Pets.Add(pet);
            return Ok(result);
        }

    }
}
