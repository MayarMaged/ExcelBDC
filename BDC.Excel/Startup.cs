using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BDC.Excel.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using BDC.Excel.Services;

namespace BDC.Excel
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddMvcOptions(o =>
            {
                o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                o.EnableEndpointRouting = false;
            }); ;
            var connectionstring = @"Server=localhost; Database=BDC; Trusted_Connection=True;";
            services.AddDbContext<BDCContext>(o => 
            {
                o.UseSqlServer(connectionstring);
            });
            services.AddScoped<IBDCEntryRepo, BDCEntryRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
