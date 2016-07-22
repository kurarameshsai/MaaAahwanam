namespace MaaAahwanam.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrations_date_07222016 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TempVenueDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VenueType = c.String(),
                        BestSuited = c.String(),
                        VenueConfig = c.String(),
                        ContactPerson = c.String(),
                        Address = c.String(),
                        Localities = c.String(),
                        VenueArea = c.String(),
                        DiningArea = c.String(),
                        IndoorSpace = c.String(),
                        OutdoorSpace = c.String(),
                        RoomsAvailable = c.String(),
                        Numofrooms = c.String(),
                        EstablishedDate = c.String(),
                        EventDescription = c.String(),
                        EmailID = c.String(),
                        BookingAdvanceAmount = c.Decimal(precision: 18, scale: 2),
                        BookingTotalAmount = c.Decimal(precision: 18, scale: 2),
                        PaymentMode = c.String(),
                        ManagerAvl = c.String(),
                        ManagerContactInfo = c.String(),
                        Images = c.String(),
                        TwoWheelerPlace = c.String(),
                        FourWheelerPlace = c.String(),
                        CateringContactInfo = c.String(),
                        FoodType = c.String(),
                        CateringIndoorCap = c.String(),
                        CateringOutdoorCap = c.String(),
                        Alchol = c.String(),
                        Wifi = c.String(),
                        Tables = c.String(),
                        Stage = c.String(),
                        Washrooms = c.String(),
                        Openairspace = c.String(),
                        Dj = c.String(),
                        Elevator = c.String(),
                        DecoratorContactInfo = c.String(),
                        DecorationType = c.String(),
                        PhotographerContactInfo = c.String(),
                        Videographercontactinfo = c.String(),
                        LCDProjector = c.String(),
                        Overheadprojector = c.String(),
                        FullAudioandVideo = c.String(),
                        Builtinscreens = c.String(),
                        MenBoutiqueContactInfo = c.String(),
                        WomenBoutiqueContactInfo = c.String(),
                        Halltype = c.String(),
                        Venuename = c.String(),
                        CancelPolicy = c.String(),
                        AvgEvents = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TempVenueDetails");
        }
    }
}
