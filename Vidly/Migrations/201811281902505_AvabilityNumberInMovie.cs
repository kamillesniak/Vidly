namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AvabilityNumberInMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AvabilityNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AvabilityNumber");
        }
    }
}
