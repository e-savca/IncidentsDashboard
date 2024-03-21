using Application.Interfaces;
using Domain.Incidents;
using Domain.Incidents.IncidentTypes;
using Domain.Incidents.ThreatsAndScenarios;
using Domain.Users;
using Persistance.Incidents;
using Persistance.Incidents.IncidentTypes;
using Persistance.Incidents.ThreatAndScenarios;
using Persistance.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistance
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Threat> Threats { get; set; }
        public DbSet<Scenario> Scenarios { get; set; }
        public DbSet<Ambit> Ambits { get; set; }
        public DbSet<IncidentType> IncidentTypes { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<AmbitsToTypes> AmbitsToTypes { get; set; }
        public DbSet<OriginToAmbit> OriginToAmbits { get; set; }


        public DatabaseService() : base("DefaultConnection")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
        public void Save()
        {
            this.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            var r = await this.SaveChangesAsync();
            return r;
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            var r = await this.SaveChangesAsync(cancellationToken);
            return r;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());

            modelBuilder.Configurations.Add(new AmbitConfiguration());
            modelBuilder.Configurations.Add(new AmbitsToTypesConfiguration());
            modelBuilder.Configurations.Add(new IncidentTypesConfiguration());
            modelBuilder.Configurations.Add(new OriginConfiguration());
            modelBuilder.Configurations.Add(new OriginToAmbitConfiguration());

            modelBuilder.Configurations.Add(new ScenarioConfiguration());
            modelBuilder.Configurations.Add(new ThreatConfiguration());

            modelBuilder.Configurations.Add(new IncidentConfiguration());
        }
    }
}
