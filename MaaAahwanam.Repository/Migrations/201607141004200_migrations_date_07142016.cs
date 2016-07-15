namespace MaaAahwanam.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrations_date_07142016 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "OrderNo", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "OrderNo");
        }
    }
}
