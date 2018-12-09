﻿// <auto-generated />
using System;
using FastFoodWorkshop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FastFoodWorkshop.Data.Migrations
{
    [DbContext(typeof(FastFoodWorkshopDbContext))]
    [Migration("20181208203020_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FastFoodWorkshop.Models.ApplicantCV", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("ApplicantFirstName");

                    b.Property<string>("ApplicantLastName");

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("Email");

                    b.Property<int?>("EmployeeId");

                    b.Property<bool>("IsHired");

                    b.Property<string>("MotivationalLetter");

                    b.Property<string>("PhoneNumber");

                    b.Property<byte[]>("Picture");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique()
                        .HasFilter("[EmployeeId] IS NOT NULL");

                    b.ToTable("ApplicantsCVs");
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.Complaint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfComplaint");

                    b.Property<string>("Description");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("FastFoodUserId");

                    b.Property<int>("RestaurantId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FastFoodUserId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.DeliveryCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("ConsumptionPerMile");

                    b.Property<int?>("EmployeeId");

                    b.Property<decimal>("FuelPrice");

                    b.Property<double>("Mileage");

                    b.Property<double>("MilesTravelledPerDay");

                    b.Property<string>("Model");

                    b.Property<DateTime>("ProductionDate");

                    b.Property<int?>("RestaurantId");

                    b.Property<double>("TankCapacity");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique()
                        .HasFilter("[EmployeeId] IS NOT NULL");

                    b.HasIndex("RestaurantId");

                    b.ToTable("DeliveryCars");
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicantCVId");

                    b.Property<DateTime?>("EndYear");

                    b.Property<string>("OrganizationName");

                    b.Property<DateTime>("StartYear");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantCVId");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("Age");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("Position");

                    b.Property<int?>("RestaurantId");

                    b.Property<decimal>("Salary");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.FastFoodUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicantCVId");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("JobDescription");

                    b.Property<decimal>("Salary");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantCVId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("OrderId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfOrder");

                    b.Property<int>("EmployeeId");

                    b.Property<int?>("FastFoodUserId");

                    b.Property<int>("RestaurantId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FastFoodUserId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CarbohidratesQuantity");

                    b.Property<double>("FatQuantity");

                    b.Property<int?>("MenuId");

                    b.Property<string>("Name");

                    b.Property<byte[]>("Picture");

                    b.Property<decimal>("Price");

                    b.Property<double>("ProteinsQuantity");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FastFoodUserId");

                    b.Property<string>("RecipeDescription");

                    b.Property<byte[]>("VideoTutorial");

                    b.HasKey("Id");

                    b.HasIndex("FastFoodUserId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("ProviderKey");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("ProviderKey", "LoginProvider");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("RoleId", "UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.ApplicantCV", b =>
                {
                    b.HasOne("FastFoodWorkshop.Models.Employee", "Employee")
                        .WithOne("ApplicantCV")
                        .HasForeignKey("FastFoodWorkshop.Models.ApplicantCV", "EmployeeId");
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.Complaint", b =>
                {
                    b.HasOne("FastFoodWorkshop.Models.Employee", "Employee")
                        .WithMany("Complaints")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FastFoodWorkshop.Models.FastFoodUser", "FastFoodUser")
                        .WithMany("Complaints")
                        .HasForeignKey("FastFoodUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FastFoodWorkshop.Models.Restaurant", "Restaurant")
                        .WithMany("Complaints")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.DeliveryCar", b =>
                {
                    b.HasOne("FastFoodWorkshop.Models.Employee", "Employee")
                        .WithOne("DeliveryCar")
                        .HasForeignKey("FastFoodWorkshop.Models.DeliveryCar", "EmployeeId");

                    b.HasOne("FastFoodWorkshop.Models.Restaurant", "Restaurant")
                        .WithMany("DeliveryCars")
                        .HasForeignKey("RestaurantId");
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.Education", b =>
                {
                    b.HasOne("FastFoodWorkshop.Models.ApplicantCV", "ApplicantCV")
                        .WithMany("Schools")
                        .HasForeignKey("ApplicantCVId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.Employee", b =>
                {
                    b.HasOne("FastFoodWorkshop.Models.Restaurant", "Restaurant")
                        .WithMany("Employees")
                        .HasForeignKey("RestaurantId");
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.Job", b =>
                {
                    b.HasOne("FastFoodWorkshop.Models.ApplicantCV", "ApplicantCV")
                        .WithMany("PreviousJobs")
                        .HasForeignKey("ApplicantCVId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.Menu", b =>
                {
                    b.HasOne("FastFoodWorkshop.Models.Order", "Order")
                        .WithMany("Menus")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.Order", b =>
                {
                    b.HasOne("FastFoodWorkshop.Models.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FastFoodWorkshop.Models.FastFoodUser", "FastFoodUser")
                        .WithMany("Orders")
                        .HasForeignKey("FastFoodUserId");

                    b.HasOne("FastFoodWorkshop.Models.Restaurant", "Restaurant")
                        .WithMany("Orders")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.Product", b =>
                {
                    b.HasOne("FastFoodWorkshop.Models.Menu", "Menu")
                        .WithMany("Products")
                        .HasForeignKey("MenuId");
                });

            modelBuilder.Entity("FastFoodWorkshop.Models.Recipe", b =>
                {
                    b.HasOne("FastFoodWorkshop.Models.FastFoodUser", "FastFoodUser")
                        .WithMany("Recepies")
                        .HasForeignKey("FastFoodUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}