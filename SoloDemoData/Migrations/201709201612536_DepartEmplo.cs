namespace SoloDemoData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartEmplo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SoloEmployers", name: "DepartmentId", newName: "IDdmp");
            RenameIndex(table: "dbo.SoloEmployers", name: "IX_DepartmentId", newName: "IX_IDdmp");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SoloEmployers", name: "IX_IDdmp", newName: "IX_DepartmentId");
            RenameColumn(table: "dbo.SoloEmployers", name: "IDdmp", newName: "DepartmentId");
        }
    }
}
