namespace Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUserPropSecondNameToLastName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Users", "SecondName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "SecondName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Users", "LastName");
        }
    }
}
