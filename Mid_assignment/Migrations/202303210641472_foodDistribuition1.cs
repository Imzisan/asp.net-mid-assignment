namespace Mid_assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foodDistribuition1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FoodDistributions", "LotDistributed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FoodDistributions", "LotDistributed", c => c.Int(nullable: false));
        }
    }
}
