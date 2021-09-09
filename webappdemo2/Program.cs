using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication;
using Azure.Identity;
using Microsoft.Azure.AppConfiguration.AspNetCore;

namespace webappdemo2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        var settings = config.Build();
                        //config.AddAzureAppConfiguration(options =>
                        //options.Connect(new Uri(settings["AppConfig:Endpoint"]), new DefaultAzureCredential()));
                        config.AddAzureAppConfiguration(options =>
                        {
                            options.Connect(settings["ConnectionStrings:AppConfig"])
                                    .ConfigureKeyVault(kv =>
                                    {
                                        kv.SetCredential(new ManagedIdentityCredential());
                                    });
                        });
                    })
                    .UseStartup<Startup>();
                });
    }
}
