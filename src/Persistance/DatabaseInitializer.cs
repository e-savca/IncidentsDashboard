using Domain.Users;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistance
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseService>
    {
        protected override void Seed(DatabaseService database)
        {
            base.Seed(database);

            // Seed the database with initial data
            CreateRoles(database);
            CreateUsers(database);
            CreateUserRole(database);
        }

        private void CreateRoles(DatabaseService database)
        {
            var roles = new List<Role>
            {
                new Role { Name = "Admin" },
                new Role { Name = "Operator" },
                new Role { Name = "User" },
            };
            roles.ForEach(role => database.Roles.Add(role));
            database.SaveChanges();            
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

        private void CreateUserRole(DatabaseService database)
        {
            var users = database.Users.ToList();
            var roles = database.Roles.ToList();
            // atach roles 
            User admin = users.Where(u => u.FullName.Contains("admin")).First();
            Role adminRole = roles.Where(r => r.Name.Contains("Admin")).First();

            User operatorUser = users.Where(u => u.FullName.Contains("operator")).First();
            Role operatorRole = roles.Where(r => r.Name.Contains("operator")).First();

            User user = users.Where(u => u.FullName.Contains("user")).First();
            Role userRole = roles.Where(r => r.Name.Contains("user")).First();

            List<UserRole> userRoles = new List<UserRole>
            {
                new UserRole { User = admin, Role = adminRole },
                new UserRole { User = operatorUser, Role = operatorRole },
                new UserRole { User = user, Role = userRole }
            };

            userRoles.ForEach(item => database.UserRoles.Add(item));
            database.SaveChanges();
        }
    }
}
