namespace MaaAahwanam.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrations_date_07132016 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceResponses", "ResponseBy", c => c.Long(nullable: false));
            DropColumn("dbo.ServiceResponses", "RequestedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceResponses", "RequestedBy", c => c.Long(nullable: false));
            DropColumn("dbo.ServiceResponses", "ResponseBy");
        }
    }
}
