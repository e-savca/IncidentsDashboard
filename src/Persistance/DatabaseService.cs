﻿using Application.Interfaces;
using Domain.Incidents;
using Domain.Incidents.IncidentTypes;
using Domain.Incidents.ThreatsAndScenarios;
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
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<UserRole> UserRoles { get; set; }
        public IDbSet<Incident> Incidents { get; set; }
        public IDbSet<Threat> Threats { get; set; }
        public IDbSet<Scenario> Scenarios { get; set; }
        public IDbSet<Ambit> Ambits { get; set; }
        public IDbSet<IncidentType> IncidentTypes { get; set; }
        public IDbSet<Origin> Origins { get; set; }
        public IDbSet<AmbitsToTypes> AmbitsToTypes { get; set; }
        public IDbSet<OriginToAmbit> OriginToAmbits { get; set; }


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
            modelBuilder.Configurations.Add(new UserRoleConfiguration());

        }
    }
}
