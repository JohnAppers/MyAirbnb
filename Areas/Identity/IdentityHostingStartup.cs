﻿using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MyAirbnb.Areas.Identity.IdentityHostingStartup))]
namespace MyAirbnb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}