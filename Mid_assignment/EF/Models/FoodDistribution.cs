using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mid_assignment.EF.Models
{
    public class FoodDistribution
    {
        [Key]
        public int DistributionId { get; set; }

        [Required]
        [ForeignKey("FoodCollectionRequest")]
        public int RequestId { get; set; }

        [Required]
        public DateTime DistributionTime { get; set; }



        public virtual FoodCollectionRequest FoodCollectionRequest { get; set; }
    }
}