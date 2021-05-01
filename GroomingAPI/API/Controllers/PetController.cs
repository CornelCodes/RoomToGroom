using API.Data;
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
        public async Task<IActionResult> GetAll()
        {
            var result = await dbContext.Pets.ToListAsync();
            return Ok(result);
        }
    }
}
