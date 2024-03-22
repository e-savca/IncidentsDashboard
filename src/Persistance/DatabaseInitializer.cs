using Domain.Incidents;
using Domain.Incidents.IncidentTypes;
using Domain.Incidents.ThreatsAndScenarios;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistance
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseService>
    {
        protected override void Seed(DatabaseService database)
        {
            CreateRoles(database);
            CreateUsers(database);
            CreateUserRole(database);

            CreateOrigins(database);
            CreateAmbits(database);
            CreateIncidentTypes(database);

            CreateOriginsToAmbits(database);
            CreateAmbitsToTypes(database);

            CreateScenarios(database);
            CreateThreats(database);

            CreateIncidents(database);

            base.Seed(database);                        
        }


        #region Seed Methods

        #region Create Roles
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
        #endregion

        #region Create Users
        private void CreateUsers(DatabaseService database)
        {
            var users = new List<User>
            {
                new User { Username = "CR001", Password = "bdbb29b6e288d3b8f07a6ea80d10024bd858b85bd8125fb8d3862ffb40a770d4", FirstName = "admin", LastName = "", Email = "user1@example.com", IsActive = true },
                new User { Username = "CR002", Password = "7bc0efeb4085f459cd0474e6f5bc3ae1893a36a7b7512e427a2648a0d7b71e1e", FirstName = "operator", LastName = "", Email = "user2@example.com", IsActive = true },
                new User { Username = "CR003", Password = "5677bd6c14708bdc4a7af9e8f78a2495d8c3278a3679187cb29a14f52e9d5dec", FirstName = "user", LastName = "", Email = "user3@example.com", IsActive = true },
            };

            users.ForEach(user => database.Users.Add(user));
            database.SaveChanges();
        }
        #endregion

        #region Create UserRoles
        private void CreateUserRole(DatabaseService database)
        {
            var users = database.Users.ToList();
            var roles = database.Roles.ToList();

            // get users and roles
            User admin = users.Where(u => u.Username.Contains("cr001")).First();
            Role adminRole = roles.Where(r => r.Name.Contains("Admin")).First();

            User operatorUser = users.Where(u => u.Username.Contains("cr002")).First();
            Role operatorRole = roles.Where(r => r.Name.Contains("Operator")).First();

            User user = users.Where(u => u.Username.Contains("cr003")).First();
            Role userRole = roles.Where(r => r.Name.Contains("User")).First();

            // atach roles 
            List<UserRole> userRoles = new List<UserRole>
            {
                new UserRole { User = admin, Role = adminRole },
                new UserRole { User = admin, Role = operatorRole },
                new UserRole { User = admin, Role = userRole },
                new UserRole { User = operatorUser, Role = operatorRole },
                new UserRole { User = user, Role = userRole }
            };

            userRoles.ForEach(item => database.UserRoles.Add(item));
            database.SaveChanges();
        }
        #endregion

        #region Create Origins
        private void CreateOrigins(DatabaseService database)
        {
            var origins = new List<Origin>{
                    new Origin { Name = "Esterna" },
                    new Origin { Name = "Applicativa" },
                    new Origin { Name = "Infrastruttura" }
                };
            origins.ForEach(o => database.Origins.Add(o));

            database.SaveChanges();
        }
        #endregion

        #region Create Ambits
        private void CreateAmbits(DatabaseService database)
        {
            var ambits = new List<Ambit>{
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
                    new Ambit { Name = "Software di base host" },
                    new Ambit { Name = "Sicurezza" },
                    new Ambit { Name = "Fasi" },
                    new Ambit { Name = "CICS" },
                    new Ambit { Name = "Release" },
                    new Ambit { Name = "Reti" }
                };

            ambits.ForEach(a => database.Ambits.Add(a));
            database.SaveChanges();
        }
        #endregion

        #region Create IncidentTypes
        private void CreateIncidentTypes(DatabaseService database)
        {
            var incidentTypes = new List<IncidentType>{
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

            incidentTypes.ForEach(i => database.IncidentTypes.Add(i));
            database.SaveChanges();
        }
        #endregion

        #region Create OriginsToAmbits

        private void CreateOriginsToAmbits(DatabaseService database)
        {
            // get all origins and ambits
            var origins = database.Origins.ToList();
            var ambits = database.Ambits.ToList();

            // get origins
            var esternaOrigin = origins.Where(o => o.Name.Contains("Esterna")).First();
            var applicativaOrigin = origins.Where(o => o.Name.Contains("Applicativa")).First();
            var infrastrutturaOrigin = origins.Where(o => o.Name.Contains("Infrastruttura")).First();

            // get ambits Ambit 
            var funzionalitaAmbit = ambits.Where(a => a.Name.Contains("Funzionalità")).First();
            var servizioAmbit = ambits.Where(a => a.Name.Contains("Servizio")).First();
            var software = ambits.Where(a => a.Name.Contains("Software")).First();
            var hardwareHostAmbit = ambits.Where(a => a.Name.Contains("Hardware Host")).First();
            var middlewareAmbit = ambits.Where(a => a.Name.Contains("Middleware")).First();
            var softwareDiBaseOpenAmbit = ambits.Where(a => a.Name.Contains("Software di base open")).First();
            var softwareDiServizioAmbit = ambits.Where(a => a.Name.Contains("Software di servizio")).First();
            var storageAmbit = ambits.Where(a => a.Name.Contains("Storage")).First();
            var canaliDiTrasmissioneAmbit = ambits.Where(a => a.Name.Contains("Canali di Trasmissione")).First();
            var databaseAmbit = ambits.Where(a => a.Name.Contains("Database")).First();
            var hardwareOpenAmbit = ambits.Where(a => a.Name.Contains("Hardware Open")).First();
            var softwareDiBaseHostAmbit = ambits.Where(a => a.Name.Contains("Software di base host")).First();
            var sicurezzaAmbit = ambits.Where(a => a.Name.Contains("Sicurezza")).First();
            var fasiAmbit = ambits.Where(a => a.Name.Contains("Fasi")).First();
            var cicsAmbit = ambits.Where(a => a.Name.Contains("CICS")).First();
            var releaseAmbit = ambits.Where(a => a.Name.Contains("Release")).First();
            var retiAmbit = ambits.Where(a => a.Name.Contains("Reti")).First();

            // atach origins to ambits
            List<OriginToAmbit> originToAmbits = new List<OriginToAmbit>();

            // atach eterna
            originToAmbits.Add(new OriginToAmbit { Origin = esternaOrigin, Ambit = funzionalitaAmbit });
            originToAmbits.Add(new OriginToAmbit { Origin = esternaOrigin, Ambit = servizioAmbit });
            originToAmbits.Add(new OriginToAmbit { Origin = esternaOrigin, Ambit = software });

            // atach applicativa
            originToAmbits.Add(new OriginToAmbit { Origin = applicativaOrigin, Ambit = software });
            originToAmbits.Add(new OriginToAmbit { Origin = applicativaOrigin, Ambit = fasiAmbit });
            originToAmbits.Add(new OriginToAmbit { Origin = applicativaOrigin, Ambit = funzionalitaAmbit });
            originToAmbits.Add(new OriginToAmbit { Origin = applicativaOrigin, Ambit = releaseAmbit });

            // atach infrastruttura
            originToAmbits.Add(new OriginToAmbit { Origin = infrastrutturaOrigin, Ambit = hardwareHostAmbit });
            originToAmbits.Add(new OriginToAmbit { Origin = infrastrutturaOrigin, Ambit = middlewareAmbit });
            originToAmbits.Add(new OriginToAmbit { Origin = infrastrutturaOrigin, Ambit = softwareDiBaseOpenAmbit });
            originToAmbits.Add(new OriginToAmbit { Origin = infrastrutturaOrigin, Ambit = softwareDiServizioAmbit });
            originToAmbits.Add(new OriginToAmbit { Origin = infrastrutturaOrigin, Ambit = storageAmbit });
            originToAmbits.Add(new OriginToAmbit { Origin = infrastrutturaOrigin, Ambit = canaliDiTrasmissioneAmbit });
            originToAmbits.Add(new OriginToAmbit { Origin = infrastrutturaOrigin, Ambit = databaseAmbit });
            originToAmbits.Add(new OriginToAmbit { Origin = infrastrutturaOrigin, Ambit = hardwareOpenAmbit });
            originToAmbits.Add(new OriginToAmbit { Origin = infrastrutturaOrigin, Ambit = software });
            originToAmbits.Add(new OriginToAmbit { Origin = infrastrutturaOrigin, Ambit = softwareDiBaseHostAmbit });
            originToAmbits.Add(new OriginToAmbit { Origin = infrastrutturaOrigin, Ambit = sicurezzaAmbit });
            originToAmbits.Add(new OriginToAmbit { Origin = infrastrutturaOrigin, Ambit = fasiAmbit });
            originToAmbits.Add(new OriginToAmbit { Origin = infrastrutturaOrigin, Ambit = cicsAmbit });
            originToAmbits.Add(new OriginToAmbit { Origin = infrastrutturaOrigin, Ambit = retiAmbit });

            // add to database
            originToAmbits.ForEach(item => database.OriginToAmbits.Add(item));
            database.SaveChanges();
        }

        #endregion

        #region Create AmbitsToTypes

        private void CreateAmbitsToTypes(DatabaseService database)
        {
            // get all origins and ambits
            var ambits = database.Ambits.ToList();
            var incidentTypes = database.IncidentTypes.ToList();

            // get ambits 
            var funzionalitaAmbit = ambits.Where(a => a.Name.Contains("Funzionalità")).First();
            var servizioAmbit = ambits.Where(a => a.Name.Contains("Servizio")).First();
            var software = ambits.Where(a => a.Name.Contains("Software")).First();
            var hardwareHostAmbit = ambits.Where(a => a.Name.Contains("Hardware Host")).First();
            var middlewareAmbit = ambits.Where(a => a.Name.Contains("Middleware")).First();
            var softwareDiBaseOpenAmbit = ambits.Where(a => a.Name.Contains("Software di base open")).First();
            var softwareDiServizioAmbit = ambits.Where(a => a.Name.Contains("Software di servizio")).First();
            var storageAmbit = ambits.Where(a => a.Name.Contains("Storage")).First();
            var canaliDiTrasmissioneAmbit = ambits.Where(a => a.Name.Contains("Canali di Trasmissione")).First();
            var databaseAmbit = ambits.Where(a => a.Name.Contains("Database")).First();
            var hardwareOpenAmbit = ambits.Where(a => a.Name.Contains("Hardware Open")).First();
            var softwareDiBaseHostAmbit = ambits.Where(a => a.Name.Contains("Software di base host")).First();
            var sicurezzaAmbit = ambits.Where(a => a.Name.Contains("Sicurezza")).First();
            var fasiAmbit = ambits.Where(a => a.Name.Contains("Fasi")).First();
            var cicsAmbit = ambits.Where(a => a.Name.Contains("CICS")).First();
            var releaseAmbit = ambits.Where(a => a.Name.Contains("Release")).First();
            var retiAmbit = ambits.Where(a => a.Name.Contains("Reti")).First();

            // get IncidentTypes
            var terzePartiIncidentType = incidentTypes.Where(i => i.Name.Contains("Terze Parti")).First();
            var saturazioneRisorseIncidentType = incidentTypes.Where(i => i.Name.Contains("Saturazione risorse")).First();
            var risorseInsufficientiIncidentType = incidentTypes.Where(i => i.Name.Contains("Risorse insufficienti")).First();
            var patchingIncidentType = incidentTypes.Where(i => i.Name.Contains("Patching")).First();
            var malfunzionamentoSwIncidentType = incidentTypes.Where(i => i.Name.Contains("Malfunzionamento sw")).First();
            var malfunzionamentoHwIncidentType = incidentTypes.Where(i => i.Name.Contains("Malfunzionamento hw")).First();
            var idmIncidentType = incidentTypes.Where(i => i.Name.Contains("IDM")).First();
            var firewallIncidentType = incidentTypes.Where(i => i.Name.Contains("Firewall")).First();
            var degradoIncidentType = incidentTypes.Where(i => i.Name.Contains("Degrado")).First();
            var configurazioniIncidentType = incidentTypes.Where(i => i.Name.Contains("Configurazioni")).First();
            var codiceIncidentType = incidentTypes.Where(i => i.Name.Contains("Codice")).First();
            var changeErratoIncidentType = incidentTypes.Where(i => i.Name.Contains("Change errato")).First();
            var certificatiIncidentType = incidentTypes.Where(i => i.Name.Contains("Certificati")).First();
            var bloccoIncidentType = incidentTypes.Where(i => i.Name.Contains("Blocco")).First();
            var attacchiInformaticiIncidentType = incidentTypes.Where(i => i.Name.Contains("Attacchi Informatici")).First();
            var accessiIncidentType = incidentTypes.Where(i => i.Name.Contains("Accessi")).First();

            // atach origins to ambits
            var ambitsToTypes = new List<AmbitsToTypes>();

            ambitsToTypes.AddRange(new List<AmbitsToTypes>
            {
                // atach Canali di Trasmissione
                new AmbitsToTypes { Ambit = canaliDiTrasmissioneAmbit, IncidentType = risorseInsufficientiIncidentType },
                new AmbitsToTypes { Ambit = canaliDiTrasmissioneAmbit, IncidentType = malfunzionamentoSwIncidentType },
                new AmbitsToTypes { Ambit = canaliDiTrasmissioneAmbit, IncidentType = configurazioniIncidentType },

                // atach CICS
                new AmbitsToTypes { Ambit = cicsAmbit, IncidentType = malfunzionamentoHwIncidentType },
                new AmbitsToTypes { Ambit = cicsAmbit, IncidentType = configurazioniIncidentType },

                // atach Database
                new AmbitsToTypes { Ambit = databaseAmbit, IncidentType = risorseInsufficientiIncidentType },
                new AmbitsToTypes { Ambit = databaseAmbit, IncidentType = malfunzionamentoSwIncidentType },
                new AmbitsToTypes { Ambit = databaseAmbit, IncidentType = malfunzionamentoHwIncidentType },
                new AmbitsToTypes { Ambit = databaseAmbit, IncidentType = degradoIncidentType },

                // atach Fasi
                new AmbitsToTypes { Ambit = fasiAmbit, IncidentType = malfunzionamentoSwIncidentType },
                new AmbitsToTypes { Ambit = fasiAmbit, IncidentType = configurazioniIncidentType },

                // atach Funzionalità
                new AmbitsToTypes { Ambit = funzionalitaAmbit, IncidentType = terzePartiIncidentType },
                new AmbitsToTypes { Ambit = funzionalitaAmbit, IncidentType = malfunzionamentoSwIncidentType },

                // atach Hardware Host
                new AmbitsToTypes { Ambit = hardwareHostAmbit, IncidentType = risorseInsufficientiIncidentType },
                new AmbitsToTypes { Ambit = hardwareHostAmbit, IncidentType = saturazioneRisorseIncidentType },

                // atach Hardware Open
                new AmbitsToTypes { Ambit = hardwareOpenAmbit, IncidentType = bloccoIncidentType },
                new AmbitsToTypes { Ambit = hardwareOpenAmbit, IncidentType = changeErratoIncidentType },
                new AmbitsToTypes { Ambit = hardwareOpenAmbit, IncidentType = degradoIncidentType },
                new AmbitsToTypes { Ambit = hardwareOpenAmbit, IncidentType = risorseInsufficientiIncidentType },

                // atach Middleware
                new AmbitsToTypes { Ambit = middlewareAmbit, IncidentType = changeErratoIncidentType },
                new AmbitsToTypes { Ambit = middlewareAmbit, IncidentType = malfunzionamentoSwIncidentType },
                new AmbitsToTypes { Ambit = middlewareAmbit, IncidentType = risorseInsufficientiIncidentType },
                new AmbitsToTypes { Ambit = middlewareAmbit, IncidentType = saturazioneRisorseIncidentType },

                // Atach Release
                new AmbitsToTypes { Ambit = releaseAmbit, IncidentType = changeErratoIncidentType },

                // Atach Reti
                new AmbitsToTypes { Ambit = retiAmbit, IncidentType = changeErratoIncidentType },

                // Atach Servizio
                new AmbitsToTypes { Ambit = servizioAmbit, IncidentType = terzePartiIncidentType },

                // Atach Sicurezza
                new AmbitsToTypes { Ambit = sicurezzaAmbit, IncidentType = accessiIncidentType },
                new AmbitsToTypes { Ambit = sicurezzaAmbit, IncidentType = attacchiInformaticiIncidentType },
                new AmbitsToTypes { Ambit = sicurezzaAmbit, IncidentType = certificatiIncidentType },
                new AmbitsToTypes { Ambit = sicurezzaAmbit, IncidentType = configurazioniIncidentType },
                new AmbitsToTypes { Ambit = sicurezzaAmbit, IncidentType = firewallIncidentType },
                new AmbitsToTypes { Ambit = sicurezzaAmbit, IncidentType = idmIncidentType },
                new AmbitsToTypes { Ambit = sicurezzaAmbit, IncidentType = patchingIncidentType },

                // Atach Software
                new AmbitsToTypes { Ambit = software, IncidentType = changeErratoIncidentType },
                new AmbitsToTypes { Ambit = software, IncidentType = codiceIncidentType },
                new AmbitsToTypes { Ambit = software, IncidentType = configurazioniIncidentType },
                new AmbitsToTypes { Ambit = software, IncidentType = risorseInsufficientiIncidentType },
                new AmbitsToTypes { Ambit = software, IncidentType = saturazioneRisorseIncidentType },
                new AmbitsToTypes { Ambit = software, IncidentType = terzePartiIncidentType },

                // Atach Software di base host
                new AmbitsToTypes { Ambit = softwareDiBaseHostAmbit, IncidentType = risorseInsufficientiIncidentType },

                // Atach Software di base open
                new AmbitsToTypes { Ambit = softwareDiBaseOpenAmbit, IncidentType = risorseInsufficientiIncidentType },
                new AmbitsToTypes { Ambit = softwareDiBaseOpenAmbit, IncidentType = saturazioneRisorseIncidentType },

                // Atach Software di servizio
                new AmbitsToTypes { Ambit = softwareDiServizioAmbit, IncidentType = bloccoIncidentType },
                new AmbitsToTypes { Ambit = softwareDiServizioAmbit, IncidentType = degradoIncidentType },
                new AmbitsToTypes { Ambit = softwareDiServizioAmbit, IncidentType = saturazioneRisorseIncidentType },


                // Atach Storage
                new AmbitsToTypes { Ambit = storageAmbit, IncidentType = saturazioneRisorseIncidentType }
            });

            // add to database
            ambitsToTypes.ForEach(item => database.AmbitsToTypes.Add(item));
            database.SaveChanges();
        }

        #endregion

        #region Create Scenarios
        private void CreateScenarios(DatabaseService database)
        {
            // create scenarios
            var scenarios = new List<Scenario> {
                new Scenario { Name = "Scenario 1", Code = "C1"},
                new Scenario { Name = "Scenario 2", Code = "C2"},
                new Scenario { Name = "Scenario 3", Code = "C3"}
            };

            // add to database
            scenarios.ForEach(s => database.Scenarios.Add(s));
            database.SaveChanges();
        }
        #endregion

        #region Create Threats

        private void CreateThreats(DatabaseService database)
        {
            // create threats
            var threats = new List<Threat>
            {
                new Threat { Name = "Threat 1", Code = "T1"},
                new Threat { Name = "Threat 2", Code = "T2"},
                new Threat { Name = "Threat 3", Code = "T3"}
            };

            // add to database
            threats.ForEach(t => database.Threats.Add(t));
            database.SaveChanges();
        }

        #endregion

        #region Create Incidents
        private void CreateIncidents(DatabaseService database)
        {
            // create incidents
            var incidents = new List<Incident>
            {
                new Incident
                {
                    CallCode = "CC1",
                    SubsystemCode = "SC1",
                    OpenedDate = DateTime.Now,
                    ClosedDate = DateTime.Now.AddDays(1),
                    RequestType = "Type1",
                    ApplicationType = "App1",
                    Urgency = "High",
                    SubCause = "SubCause1",
                    Summary = "Summary1",
                    Description = "Description1",
                    Solution = "Solution1",
                    OriginId = 1,
                    AmbitId = 1,
                    IncidentTypeId = 1,
                    ScenarioId = 1,
                    ThreatId = 1
                },
                new Incident
                {
                    CallCode = "CC2",
                    SubsystemCode = "SC2",
                    OpenedDate = DateTime.Now.AddDays(-1),
                    ClosedDate = DateTime.Now.AddDays(3),
                    RequestType = "Type2",
                    ApplicationType = "App2",
                    Urgency = "High",
                    SubCause = "SubCause2",
                    Summary = "Summary2",
                    Description = "Description2",
                    Solution = "Solution2",
                    OriginId = 2,
                    AmbitId = 2,
                    IncidentTypeId = 2,
                    ScenarioId = 2,
                    ThreatId = 2
                }
            };

            // add to database
            incidents.ForEach(i => database.Incidents.Add(i));
            database.SaveChanges();
        }

        #endregion

        #endregion
    }
}
