using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Bewerber.Data;
using GleamTech.AspNet.Core;
using Bewerber.Mail;
using Bewerber.Models;
using Microsoft.AspNetCore.Identity;
using Bewerber.Areas.Identity.Pages.Account;

namespace Bewerber
{
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
            // Add framework services.
            services.AddGleamTech();
            services.AddRazorPages();

            services
                .AddControllersWithViews()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddDbContext<BewerberContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("BewerberContext")));

            services.AddDbContext<StellenangeboteContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("BewerberContext")));
            services.AddDbContext<StellenanzeigeContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("BewerberContext")));
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();
            services.AddDbContext<BewerberContextV2>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BewerberContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseGleamTech();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
