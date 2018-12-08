namespace FastFoodWorkshop
{
    using AutoMapper;
    using Data;
    using Service;
    using Service.Contracts;
    using ServiceModels.Home;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Middleware;
    using Models;

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
                options.CheckConsentNeeded = context => true;
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
                    facebook.AppId = Configuration["Authentication:Facebook:AppId"];
                    facebook.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper(config =>
                {
                    config.CreateMap<ApplicantCvInputModel, ApplicantCV>()
                    .ForMember(dest => dest.Picture, opt => opt.Ignore());
                    config.CreateMap<JobInputModel, Job>();
                    config.CreateMap<EducationInputModel, Education>();
                });


            //App services
            services.AddScoped<RoleManager<IdentityRole<int>>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFacebookService, FacebookService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
            services.AddTransient<SeedAdminAndRolesMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger)
        {
            logger.AddFile("Log.txt");

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
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            { 
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
