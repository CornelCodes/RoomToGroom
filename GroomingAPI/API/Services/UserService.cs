using API.Data;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingAPI.Services
{
    /// <summary>
    /// Handles all user/groomer related data storage and manipulation
    /// Registered in the DI container
    /// </summary>
    public class UserService : IUserService
    {
        private User _currentUser;

        //Stores the logged in user
        public void SetUser(User currentUser)
        {
            _currentUser = currentUser;
        }

        /// <summary>
        /// Gets the current users Id if a user is logged in else returns -1
        /// </summary>
        /// <returns></returns>
        public long GetUserId()
        {
            if (_currentUser != null)
            {
                return _currentUser.UserId;
            }
            return -1;
        }

        //Sets the stored user to null
        public void LogOut()
        {
            _currentUser = null;
        }

    }
}
