namespace SoloDemoData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addsalariesfinally : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SoloSalaries",
                c => new
                    {
                        IDsal = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        validFrom = c.DateTime(nullable: false),
                        validUntil = c.DateTime(nullable: false),
                        IDemp = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDsal)
                .ForeignKey("dbo.SoloEmployers", t => t.IDemp, cascadeDelete: true)
                .Index(t => t.IDemp);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SoloSalaries", "IDemp", "dbo.SoloEmployers");
            DropIndex("dbo.SoloSalaries", new[] { "IDemp" });
            DropTable("dbo.SoloSalaries");
        }
    }
}
