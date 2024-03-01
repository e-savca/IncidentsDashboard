using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Users
{
    public class User : Entity<Guid>
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
