using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingAPI.Models
{
    /// <summary>
    /// Used to model data received when user attempts login
    /// </summary>
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
