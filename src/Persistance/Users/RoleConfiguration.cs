using Domain.User;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Users
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            this.HasKey(r => r.Id);
            this.Property(r => r.Name).IsRequired().HasMaxLength(50);
        }
    }
}
