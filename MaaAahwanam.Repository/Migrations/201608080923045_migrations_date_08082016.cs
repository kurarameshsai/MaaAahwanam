namespace MaaAahwanam.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrations_date_08082016 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendormasters", "Quotation", c => c.Boolean(nullable: false));
            AddColumn("dbo.Vendormasters", "Bidding", c => c.Boolean(nullable: false));
            AddColumn("dbo.Vendormasters", "ReverseBidding", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vendormasters", "ReverseBidding");
            DropColumn("dbo.Vendormasters", "Bidding");
            DropColumn("dbo.Vendormasters", "Quotation");
        }
    }
}
