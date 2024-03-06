using System.Collections.Generic;

namespace Application.Models
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserRoleDto> UserRoles { get; set; }
    }
}
