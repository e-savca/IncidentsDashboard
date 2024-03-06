namespace Application.Models
{
    public class UserRoleDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public UserDto User { get; set; }
        public RoleDto Role { get; set; }
    }
}
