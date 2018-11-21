namespace FastFoodWorkshop.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DeliveryCar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Model { get; set; }

        public double Mileage { get; set; }

        public DateTime ProductionDate { get; set; }

        public double TankCapacity { get; set; }

        public double ConsumptionPerMile { get; set; }

        public decimal FuelPrice { get; set; }

        public double MilesTravelledPerDay { get; set; }

        public double FuelConsumption => this.MilesTravelledPerDay * this.ConsumptionPerMile;

        public decimal FuelExpense => (decimal)this.FuelConsumption * this.FuelPrice;

        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int? RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
