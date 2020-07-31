using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Interface;
using Service.Service;
using Microsoft.AspNetCore.Identity;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(env.ContentRootPath);
            builder.AddJsonFile("Config.json", optional: true, reloadOnChange: true);
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            #region Cookie
            services.ConfigureApplicationCookie(options =>
            {

                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(500);

                options.LoginPath = "";
                options.LogoutPath = "";
                options.SlidingExpiration = true;
            });
            #endregion

            services.AddDbContext<DBContext>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("ConnectionString")));


            services.AddIdentity<UserIdentity, IdentityRole>().AddEntityFrameworkStores<DBContext>();

            services.AddControllersWithViews();
            services.AddSession();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
                opt =>
                {
                    //configure your other properties
                    opt.LoginPath = "";
                });

            #region IOC
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IStateService, StateService>();
            services.AddTransient<ICountryService, CountryService>();
            #endregion

            #region json
            

            //services.Configure<EmailClass>(Configuration.GetSection("Email"));
            //services.Configure<PathsConfiguration>(Configuration.GetSection("Paths"));
            //services.Configure<SmsClass>(Configuration.GetSection("Sms"));

            
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var staticFileOptions = new StaticFileOptions { ServeUnknownFileTypes = true };
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles(staticFileOptions);

            app.UseRouting();

            app.UseAuthorization();
            app.UseCookiePolicy();

            #region Routing
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapAreaControllerRoute(
            //        name: "Machinery",
            //        areaName: "Machinery",
            //        pattern: "Machinery/{controller=MachineAds}/{action=Index}/{id?}"); ;
            //    endpoints.MapRazorPages();
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            #endregion

        }
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DBContext>
    {
        public DBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<DBContext>();
            var connectionString = configuration.GetConnectionString("ConnectionString");
            builder.UseSqlServer(connectionString, x => x.MigrationsAssembly("Data"));

            using (var context = new DBContext(builder.Options))
            {
                context.Database.Migrate();
            }

            return new DBContext(builder.Options);
        }
    }
}
