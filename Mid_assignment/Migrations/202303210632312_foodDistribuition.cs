namespace Mid_assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foodDistribuition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodDistributions", "LotDistributed", c => c.Int(nullable: false));
            DropColumn("dbo.FoodDistributions", "QuantityDistributed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FoodDistributions", "QuantityDistributed", c => c.Int(nullable: false));
            DropColumn("dbo.FoodDistributions", "LotDistributed");
        }
    }
}
