namespace FastFoodWorkshop.ServiceModels.Applicant
{
    using Common.StringConstants;
    using Common.CustomValidations;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ApplicantCvInputModel
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string ApplicantFirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string ApplicantLastName { get; set; }

        public IFormFile Picture { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        [DateRestrictBirthday(ErrorMessage = ErrorMessages.NotOldEnough)]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(2500, MinimumLength = 50)]
        public string MotivationalLetter { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(150, MinimumLength = 10)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(60, MinimumLength = 5)]
        public string Email { get; set; }


        public virtual ICollection<JobInputModel> Job { get; set; }

        public virtual ICollection<EducationInputModel> Education { get; set; }
    }
}
