namespace TLCar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "guid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "guid", c => c.Guid(nullable: false));
        }
    }
}
