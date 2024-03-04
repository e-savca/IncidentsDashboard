using Domain.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Users
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.HasKey(u => u.Id);
            //this.Property(u => u.Name).IsRequired().HasMaxLength(50);
            //this.Property(u => u.Email).IsRequired().HasMaxLength(50);
            //this.Property(u => u.Password).IsRequired().HasMaxLength(50);
        }
    }
}
