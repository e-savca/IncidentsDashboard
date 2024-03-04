using Domain.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseService>
    {
        protected override void Seed(DatabaseService database)
        {
            base.Seed(database);

            // Seed the database with initial data
            CreateUsers(database);
        }

        private void CreateUsers(DatabaseService database)
        {
            var users = new List<User>
            {
                new User { Username = "admin", FullName = "admin", Email = "user1@example.com", IsActive = true },
                new User { Username = "operator", FullName = "operator", Email = "user2@example.com", IsActive = true },
                new User { Username = "user", FullName = "user", Email = "user3@example.com", IsActive = true },
            };

            users.ForEach(user => database.Users.Add(user));
            database.SaveChanges();
        }
    }
}
