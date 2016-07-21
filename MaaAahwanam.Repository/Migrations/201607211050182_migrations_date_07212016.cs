namespace MaaAahwanam.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrations_date_07212016 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AdminTestimonials", "UpdatedBy");
            DropColumn("dbo.AdminTestimonials", "UpdatedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdminTestimonials", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.AdminTestimonials", "UpdatedBy", c => c.Long(nullable: false));
        }
    }
}
