using System.Globalization;
using HLIMS_API_MicroServices.Data;
using HLIMS_API_MicroServices.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HLIMS_API_MicroServices.Domain.Extensions;
namespace HLIMS_API_MicroServices
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
             services.AddDynamoDbObjects(_configuration);
           
           // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddCorrelationId();
           // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
           //services.AddDynamoDbObjects(_configuration);
            services.RegisterDependencies();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMvc();
            
        }
    }
}
