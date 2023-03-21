using Mid_assignment.EF.Models;
using Mid_assignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mid_assignment.EF
{
    public class Db_Connection : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<FoodCollectionRequest> FoodCollectionRequests { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<CollectionAssignment> CollectionAssignments { get; set; }
        public DbSet<FoodDistribution> FoodDistributions { get; set; }
    }
}
