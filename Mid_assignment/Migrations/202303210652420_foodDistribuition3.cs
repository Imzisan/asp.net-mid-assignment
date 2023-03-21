namespace Mid_assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foodDistribuition3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FoodDistributions", "QuantityDistributed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FoodDistributions", "QuantityDistributed", c => c.Int(nullable: false));
        }
    }
}
