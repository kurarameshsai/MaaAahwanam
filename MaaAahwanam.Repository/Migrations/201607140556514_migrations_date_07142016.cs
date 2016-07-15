namespace MaaAahwanam.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrations_date_07142016 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VendorsInvitationCards", "CardCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.VendorsInvitationCards", "CardCostWithPrint", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VendorsInvitationCards", "CardCostWithPrint", c => c.String());
            AlterColumn("dbo.VendorsInvitationCards", "CardCost", c => c.String());
        }
    }
}
