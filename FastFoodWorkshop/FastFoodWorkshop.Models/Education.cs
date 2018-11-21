namespace FastFoodWorkshop.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Education
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartYear { get; set; }

        public DateTime? EndYear { get; set; }

        [Required]
        [StringLength(50)]
        public string OrganizationName { get; set; }

        public int ApplicantCVId { get; set; }
        public virtual ApplicantCV ApplicantCV { get; set; }
    }
}
