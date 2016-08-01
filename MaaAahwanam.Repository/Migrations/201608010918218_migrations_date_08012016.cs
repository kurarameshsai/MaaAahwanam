namespace MaaAahwanam.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrations_date_08012016 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Availabledates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        vendorId = c.Long(nullable: false),
                        servicetype = c.String(),
                        availabledate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Availabledates");
        }
    }
}
