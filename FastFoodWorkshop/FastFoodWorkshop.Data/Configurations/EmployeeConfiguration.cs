namespace FastFoodWorkshop.Data.Configurations
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasMany(e => e.Orders)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.DeliveryCar)
                .WithOne(e => e.Employee)
                .HasForeignKey<DeliveryCar>(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(e => e.ApplicantCV)
                .WithOne(e => e.Employee)
                .HasForeignKey<ApplicantCV>(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(e => e.Complaints)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
