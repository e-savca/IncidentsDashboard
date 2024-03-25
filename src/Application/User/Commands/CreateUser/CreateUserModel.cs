using System.Collections.Generic;

namespace Application.User.Commands.CreateUser
{
    public class CreateUserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public List<int> RoleIds { get; set; }
    }
}
