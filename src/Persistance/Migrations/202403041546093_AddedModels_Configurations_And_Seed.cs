namespace Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModels_Configurations_And_Seed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ambits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AmbitsToTypes",
                c => new
                    {
                        AmbitId = c.Int(nullable: false),
                        IncidentTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AmbitId, t.IncidentTypeId })
                .ForeignKey("dbo.Ambits", t => t.AmbitId, cascadeDelete: true)
                .ForeignKey("dbo.IncidentTypes", t => t.IncidentTypeId, cascadeDelete: true)
                .Index(t => t.AmbitId)
                .Index(t => t.IncidentTypeId);
            
            CreateTable(
                "dbo.IncidentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Incidents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CallCode = c.String(),
                        SubsystemCode = c.String(),
                        OpenedDate = c.DateTime(nullable: false),
                        ClosedDate = c.DateTime(nullable: false),
                        RequestType = c.String(),
                        ApplicationType = c.String(),
                        Urgency = c.String(),
                        SubCause = c.String(),
                        Summary = c.String(),
                        Description = c.String(),
                        Solution = c.String(),
                        OriginId = c.Int(nullable: false),
                        AmbitId = c.Int(nullable: false),
                        IncidentTypeId = c.Int(nullable: false),
                        ScenarioId = c.Int(nullable: false),
                        ThreatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ambits", t => t.AmbitId, cascadeDelete: true)
                .ForeignKey("dbo.IncidentTypes", t => t.IncidentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Origins", t => t.OriginId, cascadeDelete: true)
                .ForeignKey("dbo.Scenarios", t => t.ScenarioId, cascadeDelete: true)
                .ForeignKey("dbo.Threats", t => t.ThreatId, cascadeDelete: true)
                .Index(t => t.OriginId)
                .Index(t => t.AmbitId)
                .Index(t => t.IncidentTypeId)
                .Index(t => t.ScenarioId)
                .Index(t => t.ThreatId);
            
            CreateTable(
                "dbo.Origins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OriginToAmbits",
                c => new
                    {
                        OriginId = c.Int(nullable: false),
                        AmbitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OriginId, t.AmbitId })
                .ForeignKey("dbo.Ambits", t => t.AmbitId, cascadeDelete: true)
                .ForeignKey("dbo.Origins", t => t.OriginId, cascadeDelete: true)
                .Index(t => t.OriginId)
                .Index(t => t.AmbitId);
            
            CreateTable(
                "dbo.Scenarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Threats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        SecondName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 150),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.AmbitsToTypes", "IncidentTypeId", "dbo.IncidentTypes");
            DropForeignKey("dbo.Incidents", "ThreatId", "dbo.Threats");
            DropForeignKey("dbo.Incidents", "ScenarioId", "dbo.Scenarios");
            DropForeignKey("dbo.Incidents", "OriginId", "dbo.Origins");
            DropForeignKey("dbo.OriginToAmbits", "OriginId", "dbo.Origins");
            DropForeignKey("dbo.OriginToAmbits", "AmbitId", "dbo.Ambits");
            DropForeignKey("dbo.Incidents", "IncidentTypeId", "dbo.IncidentTypes");
            DropForeignKey("dbo.Incidents", "AmbitId", "dbo.Ambits");
            DropForeignKey("dbo.AmbitsToTypes", "AmbitId", "dbo.Ambits");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.OriginToAmbits", new[] { "AmbitId" });
            DropIndex("dbo.OriginToAmbits", new[] { "OriginId" });
            DropIndex("dbo.Incidents", new[] { "ThreatId" });
            DropIndex("dbo.Incidents", new[] { "ScenarioId" });
            DropIndex("dbo.Incidents", new[] { "IncidentTypeId" });
            DropIndex("dbo.Incidents", new[] { "AmbitId" });
            DropIndex("dbo.Incidents", new[] { "OriginId" });
            DropIndex("dbo.AmbitsToTypes", new[] { "IncidentTypeId" });
            DropIndex("dbo.AmbitsToTypes", new[] { "AmbitId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Threats");
            DropTable("dbo.Scenarios");
            DropTable("dbo.OriginToAmbits");
            DropTable("dbo.Origins");
            DropTable("dbo.Incidents");
            DropTable("dbo.IncidentTypes");
            DropTable("dbo.AmbitsToTypes");
            DropTable("dbo.Ambits");
        }
    }
}
