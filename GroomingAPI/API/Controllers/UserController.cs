using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class UserController : Controller
    {
        public async Task<IActionResult> Login()
        {
            return Ok();
        }

        public async Task<IActionResult> Register()
        {
            return Ok();
        }

    }
}
