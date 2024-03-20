using System.Collections.Generic;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public List<int> RoleIds { get; set; }
    }
}
