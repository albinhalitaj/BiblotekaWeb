using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using BiblotekaWeb.Areas.admin.Data;
using BiblotekaWeb.Areas.admin.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BiblotekaWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddNotyf(options =>
            {
                options.DurationInSeconds = 5;
                options.Position = NotyfPosition.TopRight;
                options.IsDismissable = true;
            });
            services.AddTransient<ILibriService, LibriService>();
            services.AddControllersWithViews();
            services.AddDbContext<BiblotekaWebContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Conn")));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
            {
                options.LoginPath = "/admin";
                options.AccessDeniedPath = "/admin/ballina/accessdenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
            });
            var from = Configuration.GetSection("Mail")["From"];
            var sender = Configuration.GetSection("Gmail")["Sender"];
            var pass = Configuration.GetSection("Gmail")["Pass"];
            var port = Convert.ToInt32(Configuration.GetSection("Gmail")["Port"]);
            services.AddFluentEmail(sender, from)
                .AddRazorRenderer()
                .AddSmtpSender(new SmtpClient("smtp.gmail.com", port)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(sender, pass),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Port = port,
                    UseDefaultCredentials = false
                });
            services.AddTransient<IKlientiService, KlientiService>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseNotyf();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            RotativaConfiguration.Setup(env);
        }
    }
}
