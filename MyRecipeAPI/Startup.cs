using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MyRecipeAPI.Models;
using MyRecipeAPI.Database;
using Microsoft.Extensions.Logging;
using MyRecipeAPI.Repositories;
using MyRecipeAPI.Repositories.Implementations;

namespace MyRecipeAPI
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "My Recipe Api", Version = "v1" }));
            services.AddDbContext<RecipeDbContext>(options =>
             options.UseSqlite(Configuration["Data:MyRecipeApi:ConnectionString"]));
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            //UseInMemoryDatabase
            //      options.UseSqlServer(Configuration["Data:MyRecipeApi:ConnectionString"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(url:"/swagger/v1/swagger.json", name:"My Recipe Api"));
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
