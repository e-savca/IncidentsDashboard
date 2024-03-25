using Domain.Common;
using System.Collections.Generic;

namespace Domain.User
{
    public class Role : Entity<int>
    {
        public string Name { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }

}
