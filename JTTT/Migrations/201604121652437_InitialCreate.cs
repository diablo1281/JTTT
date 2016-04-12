namespace JTTT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FindOnWebsites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        MatchWord = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IfThenActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        con_act_type = c.Int(nullable: false),
                        find_Id = c.Int(),
                        sender_Id = c.Int(),
                        show_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FindOnWebsites", t => t.find_Id)
                .ForeignKey("dbo.SendEmails", t => t.sender_Id)
                .ForeignKey("dbo.ShowOnBrowsers", t => t.show_Id)
                .Index(t => t.find_Id)
                .Index(t => t.sender_Id)
                .Index(t => t.show_Id);
            
            CreateTable(
                "dbo.SendEmails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        to = c.String(),
                        to_name = c.String(),
                        subject = c.String(),
                        AddressOK = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShowOnBrowsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        find_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FindOnWebsites", t => t.find_Id)
                .Index(t => t.find_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IfThenActions", "show_Id", "dbo.ShowOnBrowsers");
            DropForeignKey("dbo.ShowOnBrowsers", "find_Id", "dbo.FindOnWebsites");
            DropForeignKey("dbo.IfThenActions", "sender_Id", "dbo.SendEmails");
            DropForeignKey("dbo.IfThenActions", "find_Id", "dbo.FindOnWebsites");
            DropIndex("dbo.ShowOnBrowsers", new[] { "find_Id" });
            DropIndex("dbo.IfThenActions", new[] { "show_Id" });
            DropIndex("dbo.IfThenActions", new[] { "sender_Id" });
            DropIndex("dbo.IfThenActions", new[] { "find_Id" });
            DropTable("dbo.ShowOnBrowsers");
            DropTable("dbo.SendEmails");
            DropTable("dbo.IfThenActions");
            DropTable("dbo.FindOnWebsites");
        }
    }
}
