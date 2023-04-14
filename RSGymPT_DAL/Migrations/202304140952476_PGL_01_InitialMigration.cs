namespace RSGymPT_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PGL_01_InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        Nif = c.String(nullable: false, maxLength: 9, fixedLength: true, unicode: false),
                        BirthDate = c.DateTime(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 9, fixedLength: true, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Observations = c.String(maxLength: 255),
                        IsActive = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ClientID)
                .ForeignKey("dbo.Location", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        PostalCode = c.String(nullable: false, maxLength: 8, fixedLength: true, unicode: false),
                        City = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.PersonalTrainer",
                c => new
                    {
                        PersonalTrainerID = c.Int(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 4, fixedLength: true, unicode: false),
                        Nif = c.String(nullable: false, maxLength: 9, fixedLength: true, unicode: false),
                        Phone = c.String(nullable: false, maxLength: 9, fixedLength: true, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.PersonalTrainerID)
                .ForeignKey("dbo.Location", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                        PersonalTrainerID = c.Int(nullable: false),
                        Schedule = c.DateTime(nullable: false),
                        Status = c.String(nullable: false, maxLength: 50),
                        Observations = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.Client", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.PersonalTrainer", t => t.PersonalTrainerID, cascadeDelete: false)
                .Index(t => t.ClientID)
                .Index(t => t.PersonalTrainerID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 6),
                        Password = c.String(nullable: false, maxLength: 12),
                        Profile = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Request", "PersonalTrainerID", "dbo.PersonalTrainer");
            DropForeignKey("dbo.Request", "ClientID", "dbo.Client");
            DropForeignKey("dbo.PersonalTrainer", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Client", "LocationID", "dbo.Location");
            DropIndex("dbo.Request", new[] { "PersonalTrainerID" });
            DropIndex("dbo.Request", new[] { "ClientID" });
            DropIndex("dbo.PersonalTrainer", new[] { "LocationID" });
            DropIndex("dbo.Client", new[] { "LocationID" });
            DropTable("dbo.User");
            DropTable("dbo.Request");
            DropTable("dbo.PersonalTrainer");
            DropTable("dbo.Location");
            DropTable("dbo.Client");
        }
    }
}
