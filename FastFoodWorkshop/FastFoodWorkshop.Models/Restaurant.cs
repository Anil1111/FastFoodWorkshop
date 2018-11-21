namespace FastFoodWorkshop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Restaurant
    {
        public Restaurant()
        {
            this.Orders = new HashSet<Order>();
            this.DeliveryCars = new HashSet<DeliveryCar>();
            this.Employees = new HashSet<Employee>();
            this.Complaints = new HashSet<Complaint>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        public virtual ICollection<Complaint> Complaints { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<DeliveryCar> DeliveryCars { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
