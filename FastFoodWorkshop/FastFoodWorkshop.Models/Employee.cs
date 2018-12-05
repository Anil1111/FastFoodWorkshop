namespace FastFoodWorkshop.Models
{
    using Constants;
    using Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public Employee()
        {
            this.Orders = new HashSet<Order>();
            this.Complaints = new HashSet<Complaint>();
        }

        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public EmployeePosition Position { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public decimal Salary { get; set; }

        public virtual ApplicantCV ApplicantCV { get; set; }

        public virtual DeliveryCar DeliveryCar { get; set; }

        public int? RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<Complaint> Complaints { get; set; }

        public virtual ICollection<Order>  Orders { get; set; }
    }
}
