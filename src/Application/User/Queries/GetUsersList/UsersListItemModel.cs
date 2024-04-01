using System.Collections.Generic;

namespace Application.User.Queries.GetUsersList
{
    public class UsersListItemModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public ICollection<string> UserRoles { get; set; }
    }
}
