using System;
using AspStudio.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AspStudio.Areas.Identity.IdentityHostingStartup))]
namespace AspStudio.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
								services.AddDbContext<AspStudioIdentityDbContext>(options =>
																options.UseSqlite(
																		context.Configuration.GetConnectionString("DefaultConnection")));
                //services.AddDbContext<AspStudioIdentityDbContext>(options =>
                //    options.UseSqlServer(
                //        context.Configuration.GetConnectionString("AspStudioIdentityDbContextConnection")));
                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AspStudioIdentityDbContext>();
            });
        }
    }
}