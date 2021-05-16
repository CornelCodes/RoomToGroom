using API.Data;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingAPI.Services
{
    public class UserService
    {
        private readonly GroomingDbContext _dbContext;
        public UserService(GroomingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
