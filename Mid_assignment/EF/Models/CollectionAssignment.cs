using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mid_assignment.EF.Models
{
    public class CollectionAssignment
    {

        [Key]
        public int AssignmentId { get; set; }

        [Required]
        [ForeignKey("FoodCollectionRequest")]
        public int RequestId { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [Required]
        public DateTime AssignedTime { get; set; }

        public virtual FoodCollectionRequest FoodCollectionRequest { get; set; }

        public virtual Employee Employee { get; set; }






    }
   
    
}