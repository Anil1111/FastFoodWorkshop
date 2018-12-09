namespace FastFoodWorkshop.ServiceModels.Applicant
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class JobInputModel
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string JobDescription { get; set; }
    }
}
