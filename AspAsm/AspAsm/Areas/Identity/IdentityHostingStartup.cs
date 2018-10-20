using System;
using AspAsm.Areas.Identity.Data;
using AspAsm.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AspAsm.Areas.Identity.IdentityHostingStartup))]
namespace AspAsm.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AspAsmContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AspAsmContextConnection")));

                services.AddDefaultIdentity<AspAsmUser>()
                    .AddEntityFrameworkStores<AspAsmContext>();
            });
        }
    }
}