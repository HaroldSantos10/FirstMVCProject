using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ComputProject
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
            services.AddControllersWithViews();

            //Agrega el contexto de la base de datos
            //especificamos con cual gestor vamos a trabajar
            services.AddDbContext<TVsContext>(options =>
                    options.UseMySQL(Configuration.GetConnectionString("TVsContext")));
            //Servicio para autenticacion
            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddDefaultUI()
                    .AddEntityFrameworkStores<TVsContext>()
                    .AddDefaultTokenProviders();
            //Configures the aplication cookie to redirect
            services.ConfigureApplicationCookie(options=>{
                options.LoginPath="/Login";
                options.AccessDeniedPath="/AccessDenied";
                //options.ProfilePath="/Profile";
                options.SlidingExpiration=true;
            });

            services.AddRazorPages(options=>{
                options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "/Login");
                options.Conventions.AddAreaPageRoute("Identity", "/Account/Register", "/Register");
                options.Conventions.AddAreaPageRoute("Identity", "/Account/AccessDenied", "/AccessDenied");
                options.Conventions.AddAreaPageRoute("Identity", "/Account/Manage/PersonalData", "/Profile");
            }

            );

            services.AddDbContext<TeamContext>(options =>
                    options.UseMySQL(Configuration.GetConnectionString("TeamContext")));
        }
        


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseRouting();

             app.UseStatusCodePages();//habilitar el codigo del estado de las páginas
             //authenticaciton

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
