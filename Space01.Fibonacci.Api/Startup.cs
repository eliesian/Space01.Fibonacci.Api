using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Space01.Fibonacci.Data.Models;
using Space01.Fibonacci.Data.Contexts;
using Space01.Fibonacci.Api.Extensions;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace Space01.Fibonacci.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddDbContext<FibonacciDbContext, MsSqlDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("MsSqlConnection"), b=> b.MigrationsAssembly("Space01.Fibonacci.Api")).EnableSensitiveDataLogging());
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureCustomExceptionMiddleware();

            app.UseMvc();
        }
    }
}
