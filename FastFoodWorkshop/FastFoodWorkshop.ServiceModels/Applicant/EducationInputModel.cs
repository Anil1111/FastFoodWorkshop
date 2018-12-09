namespace FastFoodWorkshop.ServiceModels.Applicant
{
    using Common.CustomValidations;
    using Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EducationInputModel
    {
        [Required]
        [DataType(DataType.DateTime)]
        [DateRestrictToday(ErrorMessage = ErrorMessages.DateCannotBeAfterToday)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [AttributeGreaterThan(CommonStrings.StartDate)]
        [DateRestrictToday(ErrorMessage = ErrorMessages.DateCannotBeAfterToday)]
        public DateTime? EndDate { get; set; }

        [Required]
        public string OrganizationName { get; set; }
    }
}
