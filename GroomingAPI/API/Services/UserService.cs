using API.Data;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingAPI.Services
{
    public class UserService : IUserService
    {
        private User _currentUser;

        public void SetUser(User currentUser)
        {
            _currentUser = currentUser;
        }

        /// <summary>
        /// Gets the current users Id
        /// </summary>
        /// <returns>-1 if user is null and userId if not</returns>
        public long GetUserId()
        {
            if (_currentUser != null)
            {
                return _currentUser.UserId;
            }
            return -1;
        }

    }
}
