using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PetController : Controller
    {
        private GroomingDbContext dbContext;

        public PetController(GroomingDbContext dbContext)
        {
            this.dbContext = dbContext;
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
            var result = await dbContext.Pets.ToListAsync();
            return Ok(result);
        }

        //Get by CustomerId
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetByCustomerId(long customerId)
        {
            var result = await dbContext.Pets.AllAsync(p => p.CustomerId == customerId);
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
