using API.Data;
using GroomingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingAPI.Controllers
{
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        private GroomingDbContext dbContext;
        public AppointmentController(GroomingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await dbContext.Appointments.ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Appointment appointment)
        {
            var result = await dbContext.Appointments.AddAsync(appointment);
            return Ok(result);
        }
    }

}
