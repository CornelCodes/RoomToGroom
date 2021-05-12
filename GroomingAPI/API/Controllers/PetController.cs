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
    public class PetController : Controller
    {
        private GroomingDbContext dbContext;

        public PetController(GroomingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await dbContext.Pets.ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pet pet)
        {
            var result = dbContext.Pets.Add(pet);
            return Ok(result);
        }

    }
}
