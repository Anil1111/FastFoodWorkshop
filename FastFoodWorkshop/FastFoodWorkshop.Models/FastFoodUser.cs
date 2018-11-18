namespace FastFoodWorkshop.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class FastFoodUser : IdentityUser<int>
    {
        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Address { get; set; }
    }
}
