namespace Mid_assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollectionAssignments",
                c => new
                    {
                        AssignmentId = c.Int(nullable: false, identity: true),
                        RequestId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        AssignedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AssignmentId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.FoodCollectionRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ContactNumber = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.FoodCollectionRequests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        RestaurantId = c.Int(nullable: false),
                        RequestTime = c.DateTime(nullable: false),
                        MaximumPreservationTime = c.Time(nullable: false, precision: 7),
                        CollectionStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.FoodDistributions",
                c => new
                    {
                        DistributionId = c.Int(nullable: false, identity: true),
                        RequestId = c.Int(nullable: false),
                        DistributionTime = c.DateTime(nullable: false),
                        QuantityDistributed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistributionId)
                .ForeignKey("dbo.FoodCollectionRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 100),
                        ContactPerson = c.String(nullable: false, maxLength: 50),
                        ContactNumber = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectionAssignments", "RequestId", "dbo.FoodCollectionRequests");
            DropForeignKey("dbo.FoodCollectionRequests", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.FoodDistributions", "RequestId", "dbo.FoodCollectionRequests");
            DropForeignKey("dbo.CollectionAssignments", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.FoodDistributions", new[] { "RequestId" });
            DropIndex("dbo.FoodCollectionRequests", new[] { "RestaurantId" });
            DropIndex("dbo.CollectionAssignments", new[] { "EmployeeId" });
            DropIndex("dbo.CollectionAssignments", new[] { "RequestId" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.FoodDistributions");
            DropTable("dbo.FoodCollectionRequests");
            DropTable("dbo.Employees");
            DropTable("dbo.CollectionAssignments");
        }
    }
}
