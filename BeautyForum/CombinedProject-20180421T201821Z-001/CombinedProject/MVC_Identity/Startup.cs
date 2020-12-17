using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MVC_Identity.Models;
using MVC_Identity.Services;

namespace MVC_Identity
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add DbContext.
            //We will usually work with this object:
            //Configuration.GetConnectionString("DefaultConnection")
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;
                    Initial Catalog=MVCIdentityDB;Integrated Security=True;
                    Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;
                    ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

            //    Microsoft.EntityFrameworkCore.InMemory = NuGet
            //    services.AddDbContext<ApplicationDbContext>(options =>
            //`       options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Configure Identity
            services.Configure<IdentityOptions>(identityOptions =>
            {
                // Password settings
                identityOptions.Password.RequireDigit = true;
                identityOptions.Password.RequiredLength = 8;
                identityOptions.Password.RequireNonAlphanumeric = false;
                identityOptions.Password.RequireUppercase = true;
                identityOptions.Password.RequireLowercase = false;

                // Lockout settings
                identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                identityOptions.Lockout.MaxFailedAccessAttempts = 10;

                // User settings
                identityOptions.User.RequireUniqueEmail = true;

                // Cookie settings
                services.Configure<CookieAuthenticationOptions>(cookieOptions =>
                {
                    //cookieOptions.LoginPath = new PathString("/<YOUR-AREA>/Account/Login");
                    cookieOptions.ExpireTimeSpan = TimeSpan.FromDays(150);
                    cookieOptions.LoginPath = new PathString("/Account/Login");
                    cookieOptions.LogoutPath = new PathString("/Account/LogOut");
                });
            });

            // Add application services.
            services.AddTransient<IEmailService, EmailService>();
            //services.AddTransient<ISmsSender, AuthMessageSender>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseStaticFiles();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=AddForum}/{action=AdminOnly}/{id?}");
                //Index
            });
        }
    }
}
