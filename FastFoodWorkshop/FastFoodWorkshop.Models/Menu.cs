namespace FastFoodWorkshop.Models
{
    using Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Menu
    {
        public Menu()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double ProteinsQuantity => this.Products.Sum(e => e.ProteinsQuantity);

        public double CarbohidratesQuantity => this.Products.Sum(e => e.CarbohidratesQuantity);

        public double FatQuantity => this.Products.Sum(e => e.FatQuantity);

        public double TotalCalories => this.Weight
            * (FoodConstants.FatCaloriesPerGram
            + FoodConstants.GarbohidrateCaloriesPerGram
            + FoodConstants.ProteinCaloriesPerGram);

        public double Weight => this.ProteinsQuantity + this.FatQuantity + this.CarbohidratesQuantity;

        public decimal Price => this.Products.Sum(e => e.Price);

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
