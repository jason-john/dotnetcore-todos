using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Todos
{
    public class Startup
    {

        private readonly IHostingEnvironment _hostingEnv;
        private IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            _hostingEnv = env;
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen(c =>
           {
               var xmlFile = $"{_hostingEnv.ApplicationName}.xml";
               var basePath = PlatformServices.Default.Application.ApplicationBasePath;
               var xmlPath = Path.Combine(basePath, xmlFile);
               
               c.SwaggerDoc("1.0", new Info { Version = "1.0", Title = "TodosAPI" });
               c.CustomSchemaIds(type => type.FriendlyId(true));
               c.DescribeAllEnumsAsStrings();
               c.DescribeAllParametersInCamelCase();

           });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc()
            .UseStatusCodePages()
            .UseSwagger()
            .UseReDoc(c =>
            {
                c.RoutePrefix = "redoc";
                c.SpecUrl = "/swagger/1.0/swagger.json";
            });
            app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/1.0/swagger.json", "TodosAPI");
           });
        }
    }
}
