using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PandemiC.Web.Client.Models;
using PandemiC.Web.Client.Services;
using PandemiC.Web.Infrastructure;
using PandemiC.Web.Repo;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using GCtry = PandemiC.Web.Global.Models.Country;
using GCtryService = PandemiC.Web.Global.Services.CountryService;
using GResto = PandemiC.Web.Global.Models.Restaurant;
using GRestoService = PandemiC.Web.Global.Services.RestaurantService;
using GTL = PandemiC.Web.Global.Models.TimeLine;
using GTLService = PandemiC.Web.Global.Services.TimeLineService;
using GUser = PandemiC.Web.Global.Models.User;
using GUserService = PandemiC.Web.Global.Services.UserService;

namespace PandemiC.Web
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

            services.AddDistributedMemoryCache();
            services.AddHttpContextAccessor();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddScoped<ISessionManager, SessionManager>();

            services.AddTransient(sp =>
            {
                HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:51380") };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                ISessionManager sessionManager = sp.GetService<ISessionManager>();
                if (sessionManager.User is not null)
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionManager.User.Token);

                return client;
            });
            services.AddTransient<IUserService<GUser>, GUserService>();
            services.AddTransient<IUserService<User>, UserService>();

            services.AddTransient<ITimeLineService<GTL>, GTLService>();
            services.AddTransient<ITimeLineService<TimeLine>, TimeLineService>();

            services.AddTransient<ICountryService<GCtry>, GCtryService>();
            services.AddTransient<ICountryService<Country>, CountryService>();

            services.AddTransient<IRestaurantService<GResto>, GRestoService>();
            services.AddTransient<IRestaurantService<Restaurant>, RestaurantService>();
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

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
