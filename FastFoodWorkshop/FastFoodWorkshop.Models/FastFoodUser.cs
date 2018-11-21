namespace FastFoodWorkshop.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class FastFoodUser : IdentityUser<int>
    {
        public FastFoodUser()
        {
            this.Recepies = new HashSet<Recipe>();
            this.Orders = new HashSet<Order>();
            this.Complaints = new HashSet<Complaint>();
        }

        [Required]
        [StringLength(60)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(60)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age => DateTime.Now.Year - BirthDate.Year;

        public virtual ICollection<Recipe> Recepies { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Complaint> Complaints { get; set; }
    }
}
