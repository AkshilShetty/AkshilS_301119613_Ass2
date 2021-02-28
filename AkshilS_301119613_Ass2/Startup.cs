using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web.Mvc;
using AkshilS_301119613_Ass2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AkshilS_301119613_Ass2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                Configuration["Data:FacultyManagement:ConnectionString"]));
            services.AddTransient<IFacultyRepository, EFFacultyRepository>();
            services.AddTransient<ICourseRepository, EFCourseRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseBrowserLink();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "Home", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "FacultyList", template: "{controller=Faculty}/{action=FacultyList}/{id?}");
                routes.MapRoute(name: "CoursesDisplay", template: "{controller=Courses}/{action=CoursesDisplay}/{id?}");
            });
            
           
        }
    }
}
