using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace AspDotnetCoreHelloWorld
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // this method runs when host is built 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // this method runs when host runs
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //PlayWithMiddleware(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void PlayWithMiddleware(IApplicationBuilder app)
        {
            app.Use(next =>
            {
                Log.Information($"middleware 1 entered");
                RequestDelegate requestDelegate = new RequestDelegate(
                    async context =>
                    {
                        await context.Response.WriteAsync($"This is middleware 1 start" + Environment.NewLine);
                        await next(context);
                        await context.Response.WriteAsync($"This is middleware 1 end" + Environment.NewLine);
                    });
                return requestDelegate;
            });
            app.Use(next =>
            {
                Log.Information($"middleware 2 entered");
                RequestDelegate requestDelegate = new RequestDelegate(
                    async context =>
                    {
                        await context.Response.WriteAsync($"This is middleware 2 start" + Environment.NewLine);
                        await next.Invoke(context);
                        await context.Response.WriteAsync($"This is middleware 2 end" + Environment.NewLine);
                    });
                return requestDelegate;
            });
            app.Use(next =>
            {
                Log.Information($"middleware 2 entered");
                RequestDelegate requestDelegate = new RequestDelegate(
                    async context =>
                    {
                        await context.Response.WriteAsync($"This is middleware 3 start" + Environment.NewLine);
                        // if end, return 404
                        await context.Response.WriteAsync($"This is middleware 3 end" + Environment.NewLine);
                    });
                return requestDelegate;
            });
        }
    }
}
