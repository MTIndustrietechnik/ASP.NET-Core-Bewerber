using System;
using Bewerber.Areas.Identity.Data;
using Bewerber.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Bewerber.Areas.Identity.IdentityHostingStartup))]
namespace Bewerber.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BewerberContextLogin>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BewerberContextLoginConnection")));

                services.AddDefaultIdentity<BewerberUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<BewerberContextLogin>();
            });
        }
    }
}