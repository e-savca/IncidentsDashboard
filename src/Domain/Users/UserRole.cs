using Domain.Common;
using System;

namespace Domain.Users
{
    public class UserRole : Entity<Guid>
    {
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }

}
