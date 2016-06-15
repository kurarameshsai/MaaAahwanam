namespace MaaAahwanam.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditLogs",
                c => new
                    {
                        AuditLogId = c.Long(nullable: false, identity: true),
                        UserName = c.String(),
                        EventDateUTC = c.DateTime(nullable: false),
                        EventType = c.Int(nullable: false),
                        TypeFullName = c.String(nullable: false, maxLength: 512),
                        RecordId = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.AuditLogId);
            
            CreateTable(
                "dbo.AuditLogDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PropertyName = c.String(nullable: false, maxLength: 256),
                        OriginalValue = c.String(),
                        NewValue = c.String(),
                        AuditLogId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuditLogs", t => t.AuditLogId, cascadeDelete: true)
                .Index(t => t.AuditLogId);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        UserLoginId = c.Long(nullable: false, identity: true),
                        UserDetailId = c.Long(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserPhone = c.String(),
                        Url = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        UserImgId = c.String(),
                        UserImgName = c.String(),
                        Status = c.String(),
                        UpdatedBy = c.Long(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserLoginId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        UserLoginId = c.Long(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        UserType = c.String(),
                        RegDate = c.DateTime(),
                        Status = c.String(),
                        UpdatedBy = c.Long(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserLoginId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuditLogDetails", "AuditLogId", "dbo.AuditLogs");
            DropIndex("dbo.AuditLogDetails", new[] { "AuditLogId" });
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserDetails");
            DropTable("dbo.AuditLogDetails");
            DropTable("dbo.AuditLogs");
        }
    }
}
