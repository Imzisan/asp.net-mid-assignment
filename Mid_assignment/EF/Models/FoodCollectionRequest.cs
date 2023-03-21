using Mid_assignment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mid_assignment.EF.Models
{
    public class FoodCollectionRequest
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }

        [Required]
        public DateTime RequestTime { get; set; }

        [Required]
        public TimeSpan MaximumPreservationTime { get; set; }

        [Required]
        public bool CollectionStatus { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<CollectionAssignment> CollectionAssignments { get; set; }

        public virtual ICollection<FoodDistribution> FoodDistributions { get; set; }
    }


}
    
