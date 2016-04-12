namespace JTTT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smthinhnew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckTemps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Temp = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.IfThenActions", "checker_Id", c => c.Int());
            CreateIndex("dbo.IfThenActions", "checker_Id");
            AddForeignKey("dbo.IfThenActions", "checker_Id", "dbo.CheckTemps", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IfThenActions", "checker_Id", "dbo.CheckTemps");
            DropIndex("dbo.IfThenActions", new[] { "checker_Id" });
            DropColumn("dbo.IfThenActions", "checker_Id");
            DropTable("dbo.CheckTemps");
        }
    }
}
