using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Test1.Extention.MiddleWare;
using Test1.Service;

namespace Test1
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
            services.AddScoped<CustomerService>();
            services.AddScoped<UserService>();
            services.AddScoped<ProductService>();
            services.AddScoped<SessionService>();
            services.AddAutoMapper(typeof(Startup));
            /*
            services.AddAuthentication("CookieAuthentication")  
                .AddCookie("CookieAuthentication", config =>  
                {  
                    config.Cookie.Name = "UserLoginCookie";
                    config.Cookie.MaxAge = new TimeSpan(0,5,0);
                    config.LoginPath = "/Login/CheckLogin";
                });  
            */
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Login/CheckLogin";
                options.LogoutPath = "/Login/Logout";
                options.Cookie.Name = "UserLoginCookie";
                options.Cookie.MaxAge = new TimeSpan(0, 5, 0);
                
            });
            services.AddControllersWithViews();
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
                app.UseExceptionHandler();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
       
            app.UseMiddleware<LoginTwice>();
           
  
            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<RemoveCookieIfNotNeeded>();

            app.UseEndpoints(endpoints =>
            {
               
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                
                endpoints.MapControllerRoute(
                    name: "customer",
                    pattern: "{controller=Customer}/{action=Create}");
               
                endpoints.MapControllerRoute(
                    name: "secure",
                    pattern: "admin/{controller=Home}/Index/{id?}");
            });
         }
    }
}
