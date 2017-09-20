namespace SoloDemoData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SoloDepartments",
                c => new
                    {
                        IDdpm = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.IDdpm);
            
            CreateTable(
                "dbo.SoloEmployers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name1 = c.String(),
                        Name2 = c.String(),
                        Name3 = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SoloDepartments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SoloEmployers", "DepartmentId", "dbo.SoloDepartments");
            DropIndex("dbo.SoloEmployers", new[] { "DepartmentId" });
            DropTable("dbo.SoloEmployers");
            DropTable("dbo.SoloDepartments");
        }
    }
}
