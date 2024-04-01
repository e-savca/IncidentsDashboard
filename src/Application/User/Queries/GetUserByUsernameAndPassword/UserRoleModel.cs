
namespace Application.User.Queries.GetUserByUsernameAndPassword
{
    public class UserRoleModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public UserByUsernameAndPasswordModel User { get; set; }
        public RoleModel Role { get; set; }
    }
}
