using System.Collections.Generic;

namespace Application.User.Queries.GetUserByUsernameAndPassword
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserRoleModel> UserRoles { get; set; }
    }
}
