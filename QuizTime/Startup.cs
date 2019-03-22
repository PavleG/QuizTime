using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using QuizTime.Models;
using QuizTime.Hubs;

namespace QuizTime
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        public IConfiguration Configuration{get;}
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSignalR();

            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(
                    Configuration["Data:QuizTimeApp:ConnectionString"]));
            services.AddTransient<IQuizRepository, EFQuizRepository>();

            services.AddDbContext<AppIdentityDbContext>(
                options => options.UseSqlServer(
                    Configuration["Data:QuizTimeIdentity:ConnectionString"]));
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<AppIdentityDbContext>()
                    .AddDefaultTokenProviders();
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSignalR(routes =>
            {
                routes.MapHub<QuizHub>("/quizHub");
            });
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedDataIdentity.EnsurePopulated(app);
        }
    }
}
