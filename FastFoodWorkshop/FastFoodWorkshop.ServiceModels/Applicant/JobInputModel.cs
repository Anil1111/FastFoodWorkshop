namespace FastFoodWorkshop.ServiceModels.Applicant
{
    using Common;
    using Common.CustomValidations;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class JobInputModel
    {
        [Required]
        [DataType(DataType.DateTime)]
        [DateRestrictToday(ErrorMessage = ErrorMessages.DateCannotBeAfterToday)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [AttributeGreaterThan(CommonStrings.StartDate)]
        [DateRestrictToday(ErrorMessage = ErrorMessages.DateCannotBeAfterToday)]
        public DateTime EndDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string JobDescription { get; set; }
    }
}

