namespace FastFoodWorkshop.Models
{
    using Constants;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string Name { get; set; }

        public double ProteinsQuantity { get; set; }

        public double CarbohidratesQuantity { get; set; }

        public double FatQuantity { get; set; }

        public double TotalCalories => this.Weight 
            * (FoodConstants.FatCaloriesPerGram 
            + FoodConstants.GarbohidrateCaloriesPerGram 
            + FoodConstants.ProteinCaloriesPerGram);

        public double Weight => this.ProteinsQuantity + this.FatQuantity + this.CarbohidratesQuantity;

        public decimal Price { get; set; }

        public byte[] Picture { get; set; }

        public int? MenuId { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
