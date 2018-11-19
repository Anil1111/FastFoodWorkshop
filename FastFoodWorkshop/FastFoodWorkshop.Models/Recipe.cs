namespace FastFoodWorkshop.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        public int FastFoodUserId { get; set; }
        public virtual FastFoodUser FastFoodUser { get; set; }

        [Required]
        [StringLength(30000, MinimumLength = 5)]
        public string RecipeDescription { get; set; }

        public byte[] VideoTutorial { get; set; }
    }
}