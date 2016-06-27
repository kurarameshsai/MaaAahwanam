namespace MaaAahwanam.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrations_date_06242016 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDetails", "AlternativeEmailID", c => c.String());
            AddColumn("dbo.UserDetails", "Country", c => c.String());
            AddColumn("dbo.UserDetails", "Gender", c => c.String());
            AddColumn("dbo.UserDetails", "Landmark", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDetails", "Landmark");
            DropColumn("dbo.UserDetails", "Gender");
            DropColumn("dbo.UserDetails", "Country");
            DropColumn("dbo.UserDetails", "AlternativeEmailID");
        }
    }
}
