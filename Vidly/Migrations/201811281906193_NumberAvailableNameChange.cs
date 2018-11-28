namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumberAvailableNameChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "AvabilityNumber");
            Sql("Update Movies SET NumberAvailable = NumberInStock");

        }

        public override void Down()
        {
            AddColumn("dbo.Movies", "AvabilityNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
