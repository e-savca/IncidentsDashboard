using Application.Models;
using System.Collections.Generic;

namespace Application.User.Queries.GetUserByUsernameAndPassword
{
    public class UserByUsernameAndPasswordModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<UserRoleDto> UserRoles { get; set; }
    }
}
