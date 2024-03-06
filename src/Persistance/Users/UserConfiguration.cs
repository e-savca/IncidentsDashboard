﻿using Domain.Users;
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
            this.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            this.Property(u => u.LastName).IsRequired().HasMaxLength(50);
            this.Property(u => u.Email).IsRequired().HasMaxLength(150);
            this.Property(u => u.Username).IsRequired().HasMaxLength(50);
        }
    }
}
