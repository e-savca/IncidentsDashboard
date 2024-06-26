﻿using Domain.Common;
using System.Collections.Generic;

namespace Domain.User
{
    public class User : Entity<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
