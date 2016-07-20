namespace MaaAahwanam.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrations_date_07182016 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VendorsCaterings", "Veg", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.VendorsCaterings", "NonVeg", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.VendorsCaterings", "MinOrder", c => c.String());
            AlterColumn("dbo.VendorsCaterings", "MaxOrder", c => c.String());
            AlterColumn("dbo.VendorsGifts", "MinOrder", c => c.String());
            AlterColumn("dbo.VendorsGifts", "MaxOrder", c => c.String());
            AlterColumn("dbo.VendorsInvitationCards", "CardCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.VendorsInvitationCards", "CardCostWithPrint", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VendorsInvitationCards", "CardCostWithPrint", c => c.String());
            AlterColumn("dbo.VendorsInvitationCards", "CardCost", c => c.String());
            AlterColumn("dbo.VendorsGifts", "MaxOrder", c => c.Int(nullable: false));
            AlterColumn("dbo.VendorsGifts", "MinOrder", c => c.Int(nullable: false));
            AlterColumn("dbo.VendorsCaterings", "MaxOrder", c => c.Int(nullable: false));
            AlterColumn("dbo.VendorsCaterings", "MinOrder", c => c.Int(nullable: false));
            AlterColumn("dbo.VendorsCaterings", "NonVeg", c => c.String());
            AlterColumn("dbo.VendorsCaterings", "Veg", c => c.String());
        }
    }
}
