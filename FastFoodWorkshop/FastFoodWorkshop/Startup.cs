﻿namespace FastFoodWorkshop
{
    using AutoMapper;
    using Common.StringConstants;
    using Data;
    using Service;
    using Service.Contracts;
    using ServiceModels.Applicant;
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Session;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Middleware;
    using Models;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using FastFoodWorkshop.ServiceModels.User;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<FastFoodWorkshopDbContext>(options =>
                options.UseLazyLoadingProxies().
                UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<FastFoodUser, IdentityRole<int>>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<FastFoodWorkshopDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication()
                .AddFacebook(facebook =>
                {
                    facebook.AppId = Configuration[Security.FacebookAppId];
                    facebook.AppSecret = Configuration[Security.FacebookSecret];
                });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            services.AddMvc(options => 
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAutoMapper(config =>
                {
                    config.CreateMap<ApplicantCvInputModel, ApplicantCV>()
                    .ForMember(dest => dest.Picture, opt => opt.Ignore());

                    config.CreateMap<JobInputModel, Job>();
                    config.CreateMap<EducationInputModel, Education>();
                    config.CreateMap<FastFoodUser, UserDetailsViewModel>()
                    .ForMember(dest => dest.Picture, opt => opt.Ignore());
                });


            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = Security.SessionCookieName;
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
            });

            //App services
            services.AddScoped<RoleManager<IdentityRole<int>>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFacebookService, FacebookService>();
            services.AddScoped<IApplicantService, ApplicantService>();
            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
            services.AddTransient<SeedAdminAndRolesMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/Log.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSeedAdminAndRoles();
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "areas",
                   template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
