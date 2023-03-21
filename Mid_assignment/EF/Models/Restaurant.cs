using Mid_assignment.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mid_assignment.Models
{
   
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string ContactPerson { get; set; }

        [Required]
        [StringLength(20)]
        public string ContactNumber { get; set; }

        public virtual ICollection<FoodCollectionRequest> FoodCollectionRequests { get; set; }
    }





}
