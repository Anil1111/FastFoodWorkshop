namespace FastFoodWorkshop.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class FastFoodWorkshopDbContext : IdentityDbContext
    {
        public FastFoodWorkshopDbContext(DbContextOptions<FastFoodWorkshopDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }
    }
}
