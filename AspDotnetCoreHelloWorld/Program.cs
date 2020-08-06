using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace AspDotnetCoreHelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().CreateLogger();

            try
            {
                Log.Information("Starting up hello world");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application hello world failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog((hostingContext, loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                //PlayWithConfigKestrel(webBuilder);
            });


        private static void PlayWithConfigKestrel(IWebHostBuilder webBuilder)
        {
            webBuilder.UseKestrel(options => 
            {
                options.Listen(IPAddress.Loopback, 12344); // listen at port 12344
            })
            .Configure(app => 
            {
                app.Run(async context => await context.Response.WriteAsync("hello from zsquared"));
            })
            .UseIIS()
            .UseIISIntegration();
        }

    }
}
