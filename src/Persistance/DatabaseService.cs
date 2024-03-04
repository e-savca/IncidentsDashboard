using Application.Interfaces;
using Domain.Users;
using Persistance.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public IDbSet<User> Users { get; set; }

        public DatabaseService() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }
}
