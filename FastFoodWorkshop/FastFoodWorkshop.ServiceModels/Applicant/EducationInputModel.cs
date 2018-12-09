namespace FastFoodWorkshop.ServiceModels.Applicant
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EducationInputModel
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartYear { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? EndYear { get; set; }

        [Required]
        public string OrganizationName { get; set; }
    }
}
