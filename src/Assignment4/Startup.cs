using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;

namespace Assignment4 {

    public class Startup {


        public Startup(IHostingEnvironment env) {
            Console.WriteLine("Server successfully initialized.");
            //
        }


        // Adds services to the container at runtime
        public void ConfigureServices(IServiceCollection services) {
            Console.WriteLine("Configuring services...");
            services.AddMvc();
        }


        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {

            Console.WriteLine("Configuring server...");

            // Allows any origins
            app.UseCors(policy => policy
            .WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader());

            // Configure the HTTP request pipeline.
            app.UseStaticFiles();

            // Add MVC to the request pipeline.
            app.UseMvc();

            Console.WriteLine("Server configured successfully.");
        }
    }
}
