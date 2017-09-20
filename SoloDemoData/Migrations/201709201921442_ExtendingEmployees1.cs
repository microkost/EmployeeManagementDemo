namespace SoloDemoData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendingEmployees1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SoloEmployers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SoloEmployers", "Email");
        }
    }
}
