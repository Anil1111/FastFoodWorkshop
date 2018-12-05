namespace FastFoodWorkshop.ServiceModels.InputModels.User
{
    using System;
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

        [Required]
        [DataType(DataType.Upload)]
        public byte[] Picture { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(2500, MinimumLength = 50)]
        public string MotivationalLetter { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(60, MinimumLength = 5)]
        public string Email { get; set; }

    }
}
