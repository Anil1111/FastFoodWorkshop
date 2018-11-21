namespace FastFoodWorkshop.Models
{
    using Constants;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ApplicantCV
    {
        public ApplicantCV()
        {
            this.PreviousJobs = new HashSet<Job>();
            this.Schools = new HashSet<Education>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ApplicantFirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string ApplicantLastName { get; set; }

        public byte[] Picture { get; set; }

        public DateTime Birthdate { get; set; }

        public int Age => DateTime.Now.Year - Birthdate.Year;

        [Required]
        [StringLength(2500, MinimumLength = 50)]
        public string MotivationalLetter { get; set; }

        [Required]
        [RegularExpression(Regex.PhoneNumberRegex)]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(Regex.EmailRegex)]
        [StringLength(60, MinimumLength = 5)]
        public string Email { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<Job> PreviousJobs { get; set; }

        public virtual ICollection<Education> Schools { get; set; }
    }
}
