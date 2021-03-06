using Prueba.Application;
using Prueba.Domain;
using Prueba.Domain.Interfaces.Helper;
using Prueba.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Prueba.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<CardService>();
            services.AddScoped<IGenericRepository<Card>, GenericRepository<Card>>();        

            services.AddSwaggerGen();
            services.AddDbContext<PruebaContext>(
                options => options
                    .UseSqlServer(Configuration.GetConnectionString("database"))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );
           


            //Abel: se agrega CORS
            services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"v1/swagger.json", "My API V1");
                });
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //Abel: se agrega CORS
            app.UseCors();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
