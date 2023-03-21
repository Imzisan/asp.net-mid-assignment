namespace Mid_assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foodDistribuition2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodDistributions", "QuantityDistributed", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FoodDistributions", "QuantityDistributed");
        }
    }
}
