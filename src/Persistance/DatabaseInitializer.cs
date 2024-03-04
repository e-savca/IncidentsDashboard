using Domain.Incidents.IncidentTypes;
using Domain.Users;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace Persistance
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseService>
    {
        protected override void Seed(DatabaseService database)
        {
            base.Seed(database);
            List<Origin> origins = CreateOrigins();
            List<Ambit> ambits = CreateAmbits();
            List<IncidentType> incidentTypes = CreateIncidentTypes();

            origins.ForEach(o => database.Origins.Add(o));
            ambits.ForEach(a => database.Ambits.Add(a));
            incidentTypes.ForEach(i => database.IncidentTypes.Add(i));

            database.SaveChanges();

            // Add AmbitsToTypes and OriginToAmbits here...
            // You need to map each Origin, Ambit, and IncidentType based on your data.
            // For example:
            // new AmbitsToTypes { AmbitId = ambits.First(a => a.Name == "Funzionalità").Id, IncidentTypeId = incidentTypes.First(i => i.Name == "Terze Parti").Id },
            // new OriginToAmbit { OriginId = origins.First(o => o.Name == "Esterna").Id, AmbitId = ambits.First(a => a.Name == "Funzionalità").Id },


            // Seed the database with initial data
            CreateRoles(database);
            CreateUsers(database);
            CreateUserRole(database);
        }

        private static List<IncidentType> CreateIncidentTypes()
        {
            return new List<IncidentType>{
                new IncidentType { Name = "Terze Parti" },
                new IncidentType { Name = "Saturazione risorse" },
                new IncidentType { Name = "Risorse insufficienti" },
                new IncidentType { Name = "Patching" },
                new IncidentType { Name = "Malfunzionamento sw" },
                new IncidentType { Name = "Malfunzionamento hw" },
                new IncidentType { Name = "IDM" },
                new IncidentType { Name = "Firewall" },
                new IncidentType { Name = "Degrado" },
                new IncidentType { Name = "Configurazioni" },
                new IncidentType { Name = "Codice" },
                new IncidentType { Name = "Change errato" },
                new IncidentType { Name = "Certificati" },
                new IncidentType { Name = "Blocco" },
                new IncidentType { Name = "Attacchi Informatici" },
                new IncidentType { Name = "Accessi" }
                };
        }

        private static List<Ambit> CreateAmbits()
        {
            return new List<Ambit>{
                    new Ambit { Name = "Funzionalità" },
                    new Ambit { Name = "Servizio" },
                    new Ambit { Name = "Software" },
                    new Ambit { Name = "Hardware Host" },
                    new Ambit { Name = "Middleware" },
                    new Ambit { Name = "Software di base open" },
                    new Ambit { Name = "Software di servizio" },
                    new Ambit { Name = "Storage" },
                    new Ambit { Name = "Canali di Trasmissione" },
                    new Ambit { Name = "Database" },
                    new Ambit { Name = "Hardware Open" },
                    new Ambit { Name = "Software" },
                    new Ambit { Name = "Software di base host" },
                    new Ambit { Name = "Sicurezza" },
                    new Ambit { Name = "Fasi" },
                    new Ambit { Name = "CICS" },
                    new Ambit { Name = "Release" },
                    new Ambit { Name = "Reti" }
                };
        }

        private static List<Origin> CreateOrigins()
        {
            return new List<Origin>{
                    new Origin { Name = "Esterna" },
                    new Origin { Name = "Applicativa" },
                    new Origin { Name = "Infrastruttura" }
                };
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
                new User { Username = "admin", FirstName = "admin", SecondName = "", Email = "user1@example.com", IsActive = true },
                new User { Username = "operator", FirstName = "operator", SecondName = "", Email = "user2@example.com", IsActive = true },
                new User { Username = "user", FirstName = "user", SecondName = "", Email = "user3@example.com", IsActive = true },
            };

            users.ForEach(user => database.Users.Add(user));
            database.SaveChanges();
        }

        private void CreateUserRole(DatabaseService database)
        {
            var users = database.Users.ToList();
            var roles = database.Roles.ToList();
            // atach roles 
            User admin = users.Where(u => u.Username.Contains("admin")).First();
            Role adminRole = roles.Where(r => r.Name.Contains("Admin")).First();

            User operatorUser = users.Where(u => u.Username.Contains("operator")).First();
            Role operatorRole = roles.Where(r => r.Name.Contains("operator")).First();

            User user = users.Where(u => u.Username.Contains("user")).First();
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
